using System.Collections.Generic;

namespace leetcode
{
    //v1 ��v2 ִ��Ч������ƺ�����˼�벻ͬ;

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

                //������ != �ķ�ʽ���һ���жϣ���Ϊ���� ���˸����������;
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

            //��������ǰ�жϣ�����������Ǳ�������;
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
                //����ʱȷ�����ַ�����޷�ɾ��;
                if (tempBackPool != 0)
                {
                    --tempBackPool;
                    continue;
                }
                else
                {
                    //���ַ��϶���ջ��Ԫ����;
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