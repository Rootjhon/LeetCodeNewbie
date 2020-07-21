using System.Collections.Generic;
using System.Text;

namespace leetcode.easy
{
    public partial class Solution
    {
        public IList<string> LetterCasePermutation_v1(string S)
        {
            var tempResult = new List<StringBuilder>() { new StringBuilder(S.Length) };
            var tempChars = S.ToCharArray();
            for (int i = 0; i < tempChars.Length; ++i)
            {
                //×ÖÄ¸;
                var templen = tempResult.Count;
                if (tempChars[i] > '9')
                {
                    //clone;
                    for (int iR = 0; iR < templen; ++iR)
                    {
                        tempResult.Add(new StringBuilder(S.Length).Append(tempResult[iR]));
                        tempResult[iR].Append((char)(tempChars[i] | ' '));
                        tempResult[templen + iR].Append((char)(tempChars[i] & '_'));
                    }
                }
                else
                {
                    foreach (var item in tempResult)
                    {
                        item.Append(tempChars[i]);
                    }
                }
            }

            var tempR = new List<string>(tempResult.Count);
            foreach (var item in tempResult)
            {
                tempR.Add(item.ToString());
            }
            return tempR;
        }

        public IList<string> LetterCasePermutation_v2(string S)
        {
            int tempLetterCount = 0;
            var tempChars = S.ToCharArray();

            foreach (var item in tempChars)
            {
                if (item > '9') tempLetterCount++;
            }

            var tempResult = new List<string>(1 << tempLetterCount);
            var tempStrBuild = new StringBuilder(S.Length);
            for (int iR = 0; iR < 1 << tempLetterCount; ++iR)
            {
                int b = 0;
                tempStrBuild.Clear();
                for (int iC = 0; iC < tempChars.Length; ++iC)
                {
                    if (tempChars[iC] > '9')
                    {
                        //letter;
                        tempStrBuild.Append(((iR >> b++) & 1) == 1 ? (char)(tempChars[iC] | ' ') : (char)(tempChars[iC] & '_'));
                    }
                    else
                    {
                        tempStrBuild.Append(tempChars[iC]);
                    }
                }
                tempResult.Add(tempStrBuild.ToString());
            }
            
            return tempResult;
        }
    }
}