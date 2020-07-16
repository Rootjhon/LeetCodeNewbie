using System.Collections.Generic;

namespace leetcode.Medium
{
    public partial class Solution
    {
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public ListNode DetectCycle_v1(ListNode head)
        {
            var tempSet = new HashSet<ListNode>();
            var tempNext = head;
            while (tempNext != null)
            {
                if (tempSet.Contains(tempNext))
                {
                    return tempNext;
                }
                tempSet.Add(tempNext);
                tempNext = tempNext.next;
            }
            return null;
        }

        public void DetectCycle_test()
        {
            var tempLoopIdx = 1;
            var tempArray = new int[] { 3, 2, 0, -4 };
            //var tempArray = new int[] { 1,2};
            var tempNodes = new List<ListNode>();
            for (int i = 0; i < tempArray.Length; ++i)
            {
                tempNodes.Add(new ListNode(tempArray[i]));
            }
            for (int i = 0; i < tempNodes.Count - 1; ++i)
            {
                tempNodes[i].next = tempNodes[i + 1];
            }
            if (tempLoopIdx != -1)
            {
                tempNodes[tempNodes.Count - 1].next = tempNodes[tempLoopIdx];
            }
            
            DetectCycle_v2(tempNodes[0]);
        }

        public ListNode DetectCycle_v2(ListNode head)
        {
            if (head == null) return null;

            var tempCur = head;
            ListNode tempSearch = head;
            //先当成追及问题，如果追上了，那么存在环;
            while (true)
            {
                tempCur = tempCur.next;

                tempSearch = tempSearch.next?.next;
                if (tempSearch == null)
                {
                    //无环;
                    return null;
                }
                if (tempSearch == tempCur)
                {
                    //追赶上了，找到了环,该点只是相遇点;
                    break;
                }
            }

            tempCur = head;
            while (tempCur != tempSearch)
            {
                tempCur = tempCur.next;
                tempSearch = tempSearch.next;
            }
            return tempSearch;
        }
    }
}