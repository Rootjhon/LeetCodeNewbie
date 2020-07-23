﻿namespace leetcode.basics
{
    //按位存储;
    public sealed class BinaryStore
    {
        #region [Fields]
        private int _StoreBucket;
        #endregion

        #region [API]
        public bool ContainType(int varVal)
        {
            return (_StoreBucket & 1 << varVal) == (1 << varVal);
        }

        public void StoreType(int varVal)
        {
            _StoreBucket = _StoreBucket | (1 << varVal);
        }

        public void DeleteStoreType(int varVal)
        {
            _StoreBucket = _StoreBucket & ~(1 << varVal);
        }
        #endregion
    }
}
