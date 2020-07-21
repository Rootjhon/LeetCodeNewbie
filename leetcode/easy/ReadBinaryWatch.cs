using System.Collections.Generic;

namespace leetcode.easy
{
    public partial class Solution
    {
        public IList<string> ReadBinaryWatch_v1(int num)
        {
            var tempR = new List<string>();
            for (int iH = 0; iH < 12; ++iH)
            {
                var tempLeftBinary1 = num - CountBinary1(iH);
                for (int iM = 0; iM < 60; ++iM)
                {
                    if (tempLeftBinary1 == CountBinary1(iM))
                    {
                        tempR.Add(string.Format("{0}:{1:D2}", iH, iM));
                    }
                }
            }
            return tempR;
        }

        private int CountBinary1(int varVal)
        {
            var tempCount = 0;
            while (varVal != 0)
            {
                varVal = varVal & (varVal - 1);
                tempCount++;
            }
            return tempCount;
        }

        //TODO - »ØËÝÐ´·¨;
        public IList<string> ReadBinaryWatch_v2(int num)
        {
            var tempR = new List<string>();

            return tempR;
        }
    }
}