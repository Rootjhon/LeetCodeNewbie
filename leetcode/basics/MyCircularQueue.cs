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
            return IsEmpty() ? -1 : _queue[_headIdx];
        }
        /// <summary>
        /// ��ȡ��βԪ�ء��������Ϊ�գ����� -1;
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            return IsEmpty() ? -1 : _queue[_tailIdx];
        }
        /// <summary>
        /// ��ѭ�����в���һ��Ԫ�ء�����ɹ������򷵻���;
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
        /// ��ѭ��������ɾ��һ��Ԫ�ء�����ɹ�ɾ���򷵻���;
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
        /// ���ѭ�������Ƿ�Ϊ��;
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _headIdx == -1;
        }
        /// <summary>
        /// ���ѭ�������Ƿ�����;
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