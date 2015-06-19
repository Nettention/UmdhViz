// UMDH Diff Viewer
// Copyright Nettention Co., Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmdhViz
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenUmdhFile_OnSelect(object sender, EventArgs e)
        {
            DialogResult r = m_openFileDialog.ShowDialog();
            if(r==DialogResult.OK)
            {
                OpenUmdhFile(m_openFileDialog.FileName);
            }
        }

        // 읽은 파일 문자열 목록
        List<string> lines = new List<string>();
        
        // 각 콜스택별 할당/해제량 정보
        Dictionary<CallStack, AmountInfo> m_callStackToAmountInfoMap = new Dictionary<CallStack, AmountInfo>();

        private void OpenUmdhFile(string fileName)
        {
            using(StreamReader stream = File.OpenText(fileName))
            {
                lines.Clear();
                m_callStackToAmountInfoMap.Clear();
                m_allocBlockListView.Items.Clear();

                // 텍스트를 읽는다.
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    lines.Add(line);
                }

                // 읽은 텍스트에서 Diff 블럭들을 추려내어 맵에 저장한다.
                int lineNum =0;
                while(lineNum < lines.Count-1)
                {
                    DiffBlockParser parser = new DiffBlockParser(lines);
                    // 블럭의 시작을 찾으면
                    if (parser.IsFirstLine(lineNum))
                    {
                        // 끝을 찾는다.
                        int startLine = lineNum;
                        int endLine = -1;
                        for (int i = lineNum + 2; i < lines.Count; i++)
                        {
                            if (parser.IsFirstLine(i) || parser.IsEndCommitment(i))
                            {
                                endLine = i - 1;
                                // 찾았으니, lineNum은 확 점프.
                                lineNum = endLine + 1;
                                break;
                            }
                        }
                        if (endLine == -1)
                        {
                            // 더 이상 블럭이 없다. 수집을 중단.
                            break;
                        }

                        // 블럭에서 정보를 추출한다.
                        KeyValuePair<CallStack, AmountInfo> b = parser.GetDiffBlock(startLine, endLine);

                        // 추출한 것을 통계에 수집한다.
                        AmountInfo oldInfo;
                        if (m_callStackToAmountInfoMap.TryGetValue(b.Key, out oldInfo))
                        {
                            oldInfo.Add(b.Value);
                        }
                        else
                        {
                            m_callStackToAmountInfoMap.Add(b.Key, b.Value);
                        }

                    }
                    else
                    {
                        // 못 찾았으니 다음줄부터..
                        // 졸라 느린 LALR이다 ㅋㅋㅋ
                        lineNum++;
                    }
                }

                
                // 통계로 수집한 것을 총 데이터 큰 순으로 정렬한다.
                List<KeyValuePair<CallStack, AmountInfo>> result = m_callStackToAmountInfoMap.OrderBy(o => o.Value.m_totalBytes).ToList();
                result.Reverse();

                // 컨트롤에서 표시될 데이터 소스에 추가한다.
                foreach (KeyValuePair<CallStack, AmountInfo> i in result)
                {
                    var LVItem = m_allocBlockListView.Items.Add(i.Value.ToString());
                    LVItem.Tag = i.Key;
                }

                m_allocBlockListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void AllocBlock_OnSelected(object sender, EventArgs e)
        {
           // 컨트롤에서 선택한 항목의 콜스택이 우측 뷰에 표시
           if(m_allocBlockListView.SelectedItems.Count>0)
           {
               m_callStackView.Items.Clear();
               CallStack callStack= (CallStack )m_allocBlockListView.SelectedItems[0].Tag;
               foreach(string s in callStack.m_lines)
               {
                   m_callStackView.Items.Add(s);
               }
               m_callStackView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
           }
        }

        private void ProudNetLink_Open(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nettention.com");
        }
    }
}
