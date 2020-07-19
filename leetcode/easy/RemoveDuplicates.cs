using System.Text;

namespace leetcode.easy
{
    public partial class Solution
    {
        public string RemoveDuplicates_v1(string S)
        {
            if(string.IsNullOrEmpty(S) || S.Length == 1) return S;

            var tempStack = new StringBuilder(S.Length);
            var tempChars = S.ToCharArray();
            for(int i = 0;i < tempChars.Length;++i)
            {
                if(tempStack.Length == 0)
                {
                    tempStack.Append(tempChars[i]);
                    continue;
                }
                if(tempChars[i] == tempStack[tempStack.Length -1])
                {
                    tempStack.Remove(tempStack.Length - 1,1);
                    continue;
                }
                tempStack.Append(tempChars[i]);
            }
            return tempStack.ToString();
        }
    }
}