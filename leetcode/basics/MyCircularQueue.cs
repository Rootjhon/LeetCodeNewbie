namespace leetcode.basics
{
    //https://leetcode-cn.com/explore/learn/card/queue-stack/216/queue-first-in-first-out-data-structure/865/;
    //�洢��ֵ��1~1000������������ʵ�ǿ�����ushort;
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
        /// �Ӷ��׻�ȡԪ�ء��������Ϊ�գ����� -1;
        /// </summary>
        /// <returns></returns>
        public int Front()
        {
            return isEmpty() ? -1 : _queue[_headIdx];
        }
        /// <summary>
        /// ��ȡ��βԪ�ء��������Ϊ�գ����� -1;
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            return isFull() ? -1 : _queue[_tailIdx];
        }
        /// <summary>
        /// ��ѭ�����в���һ��Ԫ�ء�����ɹ������򷵻���;
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
        /// ��ѭ��������ɾ��һ��Ԫ�ء�����ɹ�ɾ���򷵻���;
        /// </summary>
        /// <returns></returns>
        public bool deQueue()
        {
            if (isEmpty()) return false;
            //++_headIdx % _queue.Length
            return false;
        }
        /// <summary>
        /// ���ѭ�������Ƿ�Ϊ��;
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return true;
        }
        /// <summary>
        /// ���ѭ�������Ƿ�����;
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