namespace leetcode.easy
{
    public partial class Solution
    {
        public int SearchInsert_v1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }
        public int SearchInsert_v2(int[] nums, int target)
        {
            if(nums == null || nums.Length == 0) return 0;
            
            int l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                // var mid = l+(r-l)/2;
                var mid = (r+l)/2;//对上行对计算化简;
                if(nums[mid] == target) return mid;
                if(nums[mid] > target)
                {
                    r = mid-1;
                }else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}