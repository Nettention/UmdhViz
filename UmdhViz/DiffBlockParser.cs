// UMDH Diff Viewer
// Copyright Nettention Co., Ltd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmdhViz
{
    class DiffBlockParser
    {
        List<String> m_lines;
        public bool m_detectedHex = false;
        string[] Tokenize(string line)
        {
            var r1 = line.Split(' ');
            // Split()을 호출해도 빈 문자열로 채워지는 경우가 있다. 그런 것들을 없앤다.
            // 안 아름다운거 알아요~ 쩝.
            List<string> r2 = new List<string>();
            foreach (string s in r1)
            {
                if (s.Length > 0)
                    r2.Add(s);
            }

            return r2.ToArray();
        }

        public DiffBlockParser(List<string> lines)
        {
            m_lines = lines;
        }

        // 16진수 문자를 가지는가?
        bool ContainsHexChar(string str)
        {
            foreach (char x in str)
            {
                if (!(x >= '0' && x <= '9'))
                {
                    return true;
                }
            }
            return false;
        }

        // 이 구문을 분석한다. BYTES_DELTA 부분을 추린다.
        // "+ BYTES_DELTA (NEW_BYTES - OLD_BYTES) NEW_COUNT allocs BackTrace TRACEID"
        // 전부는 아니고, "+ NUM ("만 분석한다. 
        // NUM은 첫 글자가 -이면 음수가 나온다.
        public bool GetDeltaInfo(string line, out long number)
        {
            number = 0;

            try
            {
                string[] words = Tokenize(line);
                if (words.Length < 3)
                    return false;

                bool positive;
                if (words[0] == "+")
                    positive = true;
                else if (words[0] == "-")
                    positive = false;
                else return false;

                if (words[2] != "(") 
                    return false;

                if (ContainsHexChar(words[1]))
                    m_detectedHex = true;

                long positiveNumber = Int64.Parse(words[1], m_detectedHex?System.Globalization.NumberStyles.HexNumber: System.Globalization.NumberStyles.Integer);
                if (!positive)
                {
                    number = -positiveNumber;
                }
                else
                    number = positiveNumber;
                
                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        public bool IsFirstLine(int lineNum)
        {
            // + or - 로 시작하는 것이 연속 두줄이면 ok
            if (lineNum + 1 >= m_lines.Count)
                return false;

            long allocBytes;
            long allocCount;

            if (!GetDeltaInfo(m_lines[lineNum], out allocBytes))
                return false;
            if (!GetDeltaInfo(m_lines[lineNum + 1], out allocCount))
            {
                return false;
            }

            return true;
        }

        public bool IsEndCommitment(int lineNum)
        {
            // 'Total'로 시작하면 끝.
            string line = m_lines[lineNum];
            string[] words = Tokenize(line);
            if (words.Length >= 1 && words[0] == "Total")
                return true;
            return false;
        }

        public KeyValuePair<CallStack, AmountInfo> GetDiffBlock(int startLine, int endLine)
        {
            KeyValuePair<CallStack, AmountInfo> ret = new KeyValuePair<CallStack, AmountInfo>(new CallStack(), new AmountInfo());

            // 1,2줄은 바이트,카운트.
            // 빈 줄은 생략하고 나머지는 콜스택.
            if (!GetDeltaInfo(m_lines[startLine], out ret.Value.m_totalBytes))
                throw new Exception("Unexpected!");

            if (!GetDeltaInfo(m_lines[startLine+1], out ret.Value.m_totalAllocCount))
                throw new Exception("Unexpected!");

            // 콜스택 저장
            for(int i=startLine+2;i<=endLine;i++)
            {
                string line = m_lines[i].Trim();
                if (line.Length > 0)
                    ret.Key.m_lines.Add(line);
            }

            return ret;
        }

    }
}
