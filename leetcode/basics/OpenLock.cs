using System.Collections.Generic;

namespace leetcode.basics
{
    public partial class Solution
    {
        public int OpenLock_v1(string[] deadends, string target)
        {
            //x to y => step = abs(y - x) % 9;
            //·ÖÎöËÀÍösolt;
            var tempDeadSoltSet = new List<HashSet<int>>(4) { new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), new HashSet<int>() };
            for (int iD = 0; iD < deadends.Length; ++iD)
            {
                var tempVal = DecodeSoltVal(deadends[iD]);
                for (int j = 0; j < tempVal.Length; j++)
                {
                    tempDeadSoltSet[j].Add(tempVal[j]);
                }
            }

            return -1;
        }

        private int[] DecodeSoltVal(string varVal)
        {
            var tempSolt = new int[4];
            for (int iC = 0; iC < varVal.Length; ++iC)
            {
                tempSolt[iC] = varVal[iC] - '0';
            }
            return tempSolt;
        }
    }
}