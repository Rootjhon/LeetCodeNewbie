using System;
using System.Diagnostics;
using leetcode.Medium;

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

            //tempP.IsValid_v1("({})");
            //tempP.BackspaceCompare("ab#c", "ad#c");
            //tempP.BackspaceCompare_v1("ab##", "c#d#");
            //tempP.BackspaceCompare_v1("bxj##tw", "bxj###tw");
            //tempP.BackspaceCompare_v1("a#c", "t#b");

            //binarySearch(new int[] { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9, 3, 4 }, 7);

            //MinStack minStack = new MinStack();
            ////minStack.Push(-2);
            ////minStack.Push(0);
            ////minStack.Push(-3);
            //minStack.Push(2147483646);
            //minStack.Push(2147483646);
            //minStack.Push(2147483647);
            //minStack.Pop();
            //minStack.Pop();
            //minStack.Pop();
            //minStack.Push(2147483647);
            //minStack.Push(-2147483648);
            //minStack.Pop();
            //minStack.GetMin();

            tempP.DetectCycle_test();

            _watch.Stop();

            Console.WriteLine(_watch.ElapsedMilliseconds);
        }

        public static int binarySearch(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                var mid = l + (r - 1) >> 1;

                if (nums[mid] < target) { l = mid + 1; }
                if (nums[mid] >= target) { r = mid - 1; }
            }
            return l;
        }

    }
}
