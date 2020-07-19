using System;
using System.Diagnostics;
using leetcode.easy;
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
            
            var tempQ = new MyCircularQueue(3);
            var tempR = tempQ.EnQueue(1);
            tempR = tempQ.EnQueue(2);
            tempR = tempQ.EnQueue(3);
            tempR = tempQ.EnQueue(4);
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
