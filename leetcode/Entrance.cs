using System;
using System.Diagnostics;

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
            //tempP.Intersect_v2(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });

            //tempP.RemoveOuterParentheses_v1("(()())(())");
            //tempP.RemoveOuterParentheses_v1("(()())(())(()(()))");//"()()()()(())";
            //tempP.RemoveOuterParentheses_v1("()()");//"()()()()(())";

            //tempP.CountNegatives_v2(new int[][]
            //{
            //    new int[] { 4, 3, 2, -1 }, new int[] { 3,2,1,-1 }, new int[] { 1,1,-1,-2 }, new int[] { -1, -1, -2, -3 }
            //});

            tempP.IsValid_v1("({})");

            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }
    }
}
