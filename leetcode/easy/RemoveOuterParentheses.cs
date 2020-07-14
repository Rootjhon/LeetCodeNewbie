using System;
using System.Text;

namespace leetcode
{
    public partial class Solution
    {
        public string RemoveOuterParentheses_v1(string S)
        {
            const char tempRChar = ')';

            var tempLIdx = 0;
            var tempLCount = 1;
            
            for (int iC = 1; iC < S.Length; ++iC)
            {
                var tempC = S[iC];
                if (tempC != tempRChar)
                {
                    tempLCount++;
                    continue;
                }

                if (--tempLCount != 0) continue;

                S = S.Remove(tempLIdx, 1).Remove(--iC, 1);
                tempLIdx = iC + 1;
                tempLCount = 1;
            }
            return S;
        }

        public string RemoveOuterParentheses_v2(string S)
        {
            var s = new StringBuilder();

            var level = 0;

            foreach (var item in S.ToCharArray())
            {
                if (item == ')') --level;
                if (level >= 1) s.Append(item);
                if (item == '(') ++level;
            }

            return s.ToString();
        }
    }
}