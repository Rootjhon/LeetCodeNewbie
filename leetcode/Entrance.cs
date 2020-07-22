using System;
using System.Diagnostics;
//using leetcode.easy;
using leetcode.basics;

namespace leetcode
{
    internal sealed class Entrance
    {
        #region [Fields]
        private static Stopwatch _watch = new Stopwatch();
        #endregion

        private static void Main(string[] args)
        {
            var tempP = new Solution();

            _watch.Start();

            var tempStore = new BinaryStore();

            var tempR = tempStore.ContainType(1);

            tempStore.StoreType(1);
            tempR = tempStore.ContainType(1);

            tempStore.StoreType(2);
            tempR = tempStore.ContainType(1);
            tempR = tempStore.ContainType(2);
            tempR = tempStore.ContainType(3);

            tempStore.DeleteStoreType(1);
            tempR = tempStore.ContainType(2);
            tempR = tempStore.ContainType(1);

            tempStore.DeleteStoreType(2);
            tempR = tempStore.ContainType(2);
            tempR = tempStore.ContainType(1);


            tempStore.DeleteStoreType(2);
            tempR = tempStore.ContainType(2);

            tempR = tempStore.ContainType(3);


            var tempQ = new MyCircularQueue(6);
            tempQ.EnQueue(6);
            tempQ.Rear();
            tempQ.Rear();
            tempQ.DeQueue();
            tempQ.Rear();
            tempQ.DeQueue();
            tempQ.Front();
            tempQ.DeQueue();

            tempQ.Rear();
            tempQ.IsFull();
            tempQ.DeQueue();
            tempQ.EnQueue(4);
            tempQ.Rear();


            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }


    }
}
