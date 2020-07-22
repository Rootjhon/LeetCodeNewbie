namespace leetcode.basics
{
    //https://leetcode-cn.com/explore/learn/card/queue-stack/216/queue-first-in-first-out-data-structure/865/;
    //存储的值在1~1000，数据类型其实是可以用ushort;
    public class MyCircularQueue
    {
        #region [Fields]
        private int _tailIdx;
        private int _headIdx;
        private int[] _queue;
        #endregion

        #region [Construct]
        public MyCircularQueue(int varCapacity)
        {
            _tailIdx = -1;
            _headIdx = -1;
            if (varCapacity > 0)
            {
                _queue = new int[varCapacity];
            }
        }
        #endregion

        #region [API]
        /// <summary>
        /// 从队首获取元素。如果队列为空，返回 -1;
        /// </summary>
        /// <returns></returns>
        public int Front()
        {
            return IsEmpty() ? -1 : _queue[_headIdx];
        }
        /// <summary>
        /// 获取队尾元素。如果队列为空，返回 -1;
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            return IsEmpty() ? -1 : _queue[_tailIdx];
        }
        /// <summary>
        /// 向循环队列插入一个元素。如果成功插入则返回真;
        /// </summary>
        /// <param name="varVal"></param>
        /// <returns></returns>
        public bool EnQueue(int varVal)
        {
            if (IsFull()) return false;
            if (IsEmpty()) _headIdx = 0;

            _tailIdx = ++_tailIdx % _queue.Length;
            _queue[_tailIdx] = varVal;
            return true;
        }
        /// <summary>
        /// 从循环队列中删除一个元素。如果成功删除则返回真;
        /// </summary>
        /// <returns></returns>
        public bool DeQueue()
        {
            if (IsEmpty()) return false;

            if (_headIdx == _tailIdx)
            {
                _headIdx = _tailIdx = -1;
                return true;
            }

            _headIdx = ++_headIdx % _queue.Length;
            return true;
        }
        /// <summary>
        /// 检查循环队列是否为空;
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _headIdx == -1;
        }
        /// <summary>
        /// 检查循环队列是否已满;
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if (_queue == null) return true;
            return (_tailIdx + 1) % _queue.Length == _headIdx;
        }
        #endregion
    }
}