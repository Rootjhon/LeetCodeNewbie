﻿using System;
using System.Collections.Generic;

namespace leetcode
{
    /// <summary>
    /// URL:https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
    /// 
    ///     给定两个数组，编写一个函数来计算它们的交集。
    ///     
    /// 示例 1：
    ///     输入：nums1 = [1,2,2,1], nums2 = [2,2]
    ///     输出：[2,2]
    ///
    /// 示例 2:
    ///     输入：nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    ///     输出：[4,9]
    ///
    /// 说明：
    ///     输出结果中每个元素出现的次数，应与元素在两个数组中出现次数的最小值一致。
    ///     我们可以不考虑输出结果的顺序。
    ///
    /// 进阶：
    ///     如果给定的数组已经排好序呢？你将如何优化你的算法？
    ///     如果 nums1 的大小比 nums2 小很多，哪种方法更优？
    ///     如果 nums2 的元素存储在磁盘上，磁盘内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？
    /// </summary>
    public partial class Solution
    {
        ///316ms;
        public int[] Intersect_V1(int[] nums1, int[] nums2)
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

        public int[] Intersect_V2(int[] nums1, int[] nums2)
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