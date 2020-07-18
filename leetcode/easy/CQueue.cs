using System.Collections.Generic;

namespace leetcode.easy
{
    //https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof/;
    //双栈实现队列;
    public sealed class CQueue
    {
        #region [Fields]
        private Stack<int> _EnStack;
        private Stack<int> _DeStack;
        #endregion

        #region [Construct]
        public CQueue()
        {
            _EnStack = new Stack<int>(256);
            _DeStack = new Stack<int>(256);
        }
        #endregion

        #region [API]
        public void AppendTail(int value)
        {
            _EnStack.Push(value);
        }

        public int DeleteHead()
        {
            if (_EnStack.Count == 0 && _DeStack.Count == 0) return -1;
            if (_DeStack.Count == 0)
            {
                //更新;
                while (_EnStack.Count != 0)
                {
                    _DeStack.Push(_EnStack.Pop());
                }
            }
            return _DeStack.Pop();
        }
        #endregion
    }
}