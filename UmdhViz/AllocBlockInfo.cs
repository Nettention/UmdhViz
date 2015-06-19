// UMDH Diff Viewer
// Copyright Nettention Co., Ltd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmdhViz
{
    class CallStack
    {
        public List<string> m_lines = new List<string>();

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            CallStack p = (CallStack)obj;
            if (p.m_lines.Count != m_lines.Count)
                return false;

            for(int i=0;i<m_lines.Count;i++)
            {
                string s1 = m_lines[i];
                string s2 = p.m_lines[i];
                if (!s1.Equals(s2))
                    return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            int ret=0;
            for (int i = 0; i < m_lines.Count; i++)
            {
                string s1 = m_lines[i];
                ret += s1.GetHashCode();
            }
            return ret;
        }
    }

    class AmountInfo
    {
        // 음수일 수 있다. 되레 해제했다면.
        public long m_totalBytes = 0;
        // 음수일 수 있다. 되레 해제했다면.
        public long m_totalAllocCount = 0;

        public void Add(AmountInfo rhs)
        {
            m_totalAllocCount += rhs.m_totalAllocCount;
            m_totalBytes += rhs.m_totalBytes;
        }

        override public string ToString()
        {
            return String.Format("{0:n0} bytes, {1:n0} allocs", m_totalBytes, m_totalAllocCount);
        }
    }

}
