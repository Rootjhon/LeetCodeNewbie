using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace leetcode
{
    class Entrance
    {
        private static Stopwatch _watch = new Stopwatch();

        static void Main(string[] args)
        {
            var tempP = new Solution();

            _watch.Start();
            tempP.Intersect_V2(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }
    }
}
