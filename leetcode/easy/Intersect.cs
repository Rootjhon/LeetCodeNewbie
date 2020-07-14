using System.Collections.Generic;

namespace leetcode
{
    public partial class Solution
    {
        public int[] Intersect_v1(int[] nums1, int[] nums2)
        {
            var tempR = nums1.Length > nums2.Length;
            var tempMin = tempR ? nums2 : nums1;
            var tempMax = tempR ? nums1 : nums2;

            var tempAnswerIdx = new List<int>();
            var tempHashIdx = new HashSet<int>();
            for (int iMi = 0; iMi < tempMin.Length; ++iMi)
            {
                var tempNum1 = tempMin[iMi];
                for (int iMa = 0; iMa < tempMax.Length; ++iMa)
                {
                    if (tempHashIdx.Contains(iMa)) continue;

                    if (tempNum1 == tempMax[iMa])
                    {
                        tempHashIdx.Add(iMa);
                        tempAnswerIdx.Add(tempNum1);
                        break;
                    }
                }
            }
            return tempAnswerIdx.ToArray();
        }

        public int[] Intersect_v2(int[] nums1, int[] nums2)
        {
            var tempR = nums1.Length > nums2.Length;
            var tempMin = tempR ? nums2 : nums1;
            var tempMax = tempR ? new List<int>(nums1) : new List<int>(nums2);

            var tempAnswerIdx = new List<int>();
            for (int iMi = 0; iMi < tempMin.Length; ++iMi)
            {
                var tempNum1 = tempMin[iMi];
                for (int iMa = 0; iMa < tempMax.Count; ++iMa)
                {
                    if (tempNum1 == tempMax[iMa])
                    {
                        tempAnswerIdx.Add(tempNum1);
                        tempMax.RemoveAt(iMa);
                        break;
                    }
                }
            }
            return tempAnswerIdx.ToArray();
        }
    }
}