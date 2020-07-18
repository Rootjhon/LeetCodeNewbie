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
            return isEmpty() ? -1 : _queue[_headIdx];
        }
        /// <summary>
        /// 获取队尾元素。如果队列为空，返回 -1;
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            return isFull() ? -1 : _queue[_tailIdx];
        }
        /// <summary>
        /// 向循环队列插入一个元素。如果成功插入则返回真;
        /// </summary>
        /// <param name="varVal"></param>
        /// <returns></returns>
        public bool enQueue(int varVal)
        {
            if (isEmpty()) return false;
            _queue[++_tailIdx % _queue.Length] = varVal;
            return true;
        }
        /// <summary>
        /// 从循环队列中删除一个元素。如果成功删除则返回真;
        /// </summary>
        /// <returns></returns>
        public bool deQueue()
        {
            if (isEmpty()) return false;
            //++_headIdx % _queue.Length
            return false;
        }
        /// <summary>
        /// 检查循环队列是否为空;
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return true;
        }
        /// <summary>
        /// 检查循环队列是否已满;
        /// </summary>
        /// <returns></returns>
        public bool isFull()
        {
            if (_queue == null) return true;
            return true;
        }
        #endregion
    }
}