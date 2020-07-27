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

            tempP.OpenLock_v1(new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888");
            //tempP.OpenLock_v1(new string[] { "0201", "0101", "0102", "1212", "2002" }, "0202");

            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }


    }
}
