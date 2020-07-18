using System;
using System.Diagnostics;
using leetcode.easy;

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
            
            var tempS = tempP.SearchInsert_v2(new int[]{1,3,5,6},0);
            Console.WriteLine(tempS);
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
