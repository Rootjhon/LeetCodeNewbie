using System.Collections.Generic;

namespace leetcode
{
    public partial class Solution
    {
        public bool IsValid_v1(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var tempChars = s.ToCharArray();
            var tempValid = new Stack<char>();
            for (int iC = 0; iC < tempChars.Length; ++iC)
            {
                var tempVal = tempChars[iC];

                char tempPair;
                if (MatchPair(tempVal, out tempPair))
                {
                    tempValid.Push(tempPair);
                }
                else
                {
                    if (tempValid.Count == 0 || tempVal != tempValid.Peek())
                    {
                        return false;
                    }
                    tempValid.Pop();
                }
            }
            return tempValid.Count == 0;
        }
        private bool MatchPair(char varVal, out char varMatch)
        {
            if (varVal == '(')
            {
                varMatch = ')';
                return true;
            }
            if (varVal == '[')
            {
                varMatch = ']';
                return true;
            }
            if (varVal == '{')
            {
                varMatch = '}';
                return true;
            }
            varMatch = ' ';
            return false;
        }


        public bool IsValid_v2(string s)
        {
            Stack<char> tempStack = new Stack<char>();
            var tempC = s.ToCharArray();
            foreach (char c in tempC)
            {
                if (c == '(')
                {
                    tempStack.Push(')');
                }
                else if (c == '{')
                {
                    tempStack.Push('}');
                }
                else if (c == '[')
                {
                    tempStack.Push(']');
                }
                else if (tempStack.Count == 0 || tempStack.Pop() != c)
                {
                    return false;
                }
            }
            return tempStack.Count == 0;
        }
    }
}
