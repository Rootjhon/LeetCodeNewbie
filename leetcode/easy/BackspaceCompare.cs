using System.Collections.Generic;

namespace leetcode
{
    //v1 和v2 执行效率相差似乎不大，思想不同;

    public partial class Solution
    {
        public bool BackspaceCompare_v1(string S, string T)
        {
            if (string.IsNullOrEmpty(S) && string.IsNullOrEmpty(T))
            {
                return true;
            }
            var tempStack = new Stack<char>(S.Length);

            //for (int iS = 0; iS < S.Length; ++iS)
            foreach (var tempVal in S.ToCharArray())
            {
                //var tempVal = S[iS];

                //这里用 != 的方式会多一次判断，因为命中 非退格的情况会更多;
                if (tempVal == '#')
                {
                    if (tempStack.Count != 0)
                    {
                        tempStack.Pop();
                    }
                }
                else
                {
                    tempStack.Push(tempVal);
                }
            }

            if (tempStack.Count == 0 && string.IsNullOrEmpty(T))
            {
                return true;
            }

            //倒序能提前中断，最差的情况就是遍历结束;
            var tempBackPool = 0;
            var tempTArray = T.ToCharArray();
            for (int iT = tempTArray.Length - 1; iT >= 0; --iT)
            {
                var tempVal = tempTArray[iT];
                if (tempVal == '#')
                {
                    tempBackPool++;
                    continue;
                }
                //倒序时确定是字符后就无法删除;
                if (tempBackPool != 0)
                {
                    --tempBackPool;
                    continue;
                }
                else
                {
                    //该字符肯定是栈顶元素了;
                    if (tempStack.Count == 0 || tempVal != tempStack.Pop())
                    {
                        return false;
                    }
                }

            }
            return tempStack.Count == 0;
        }

        public bool BackspaceCompare_v2(string S, string T)
        {
            int i = S.Length - 1, j = T.Length - 1;
            int skipS = 0, skipT = 0;

            while (i >= 0 || j >= 0)
            { // While there may be chars in build(S) or build (T)
                while (i >= 0)
                { // Find position of next possible char in build(S)
                    if (S[i] == '#') { skipS++; i--; }
                    else if (skipS > 0) { skipS--; i--; }
                    else break;
                }
                while (j >= 0)
                { // Find position of next possible char in build(T)
                    if (T[j] == '#') { skipT++; j--; }
                    else if (skipT > 0) { skipT--; j--; }
                    else break;
                }
                // If two actual characters are different
                if (i >= 0 && j >= 0 && S[i] != T[j])
                    return false;
                // If expecting to compare char vs nothing
                if ((i >= 0) != (j >= 0))
                    return false;
                i--; j--;
            }
            return true;
        }
    }
}