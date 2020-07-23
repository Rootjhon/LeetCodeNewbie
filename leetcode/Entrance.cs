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
            
            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }


    }
}
