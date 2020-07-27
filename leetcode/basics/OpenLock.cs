using System;
using System.Collections.Generic;

namespace leetcode.basics
{
    public partial class Solution
    {
        public int OpenLock_v1(string[] deadends, string target)
        {
            var tempDeadSet = new HashSet<string>(deadends);

            Queue<string> tempQueue = new Queue<string>();
            tempQueue.Enqueue("0000");
            //深度分层哨兵;
            tempQueue.Enqueue(null);

            var tempSeen = new HashSet<string>();
            tempSeen.Add(tempQueue.Peek());

            int tempDepth = 0;
            while (tempQueue.Count != 0)
            {
                var tempNode = tempQueue.Dequeue();

                if (tempNode == null)
                {
                    if (tempQueue.Count == 0) break;

                    tempDepth++;
                    if (tempQueue.Peek() != null)
                    {
                        tempQueue.Enqueue(null);
                    }
                }
                else if (tempNode == target)
                {
                    return tempDepth;
                }
                else if (!tempDeadSet.Contains(tempNode))
                {
                    for (int iS = 0; iS < 4; ++iS)
                    {
                        for (int d = -1; d <= 1; d += 2)
                        {
                            var tempY = (tempNode[iS] - '0' + d + 10) % 10;
                            var tempNei = tempNode.Substring(0, iS) + tempY.ToString() + tempNode.Substring(iS + 1);
                            if (!tempSeen.Contains(tempNei))
                            {
                                tempSeen.Add(tempNei);
                                tempQueue.Enqueue(tempNei);
                            }
                        }
                    }
                }

            }

            return -1;
        }

        public int OpenLock_v2(string[] deadends, string target)
        {
            var visit = new bool[10000];
            int targeti = int.Parse(target);
            
            foreach (string dead in deadends)
            {
                visit[int.Parse(dead)] = true;
            }

            int temDepth = 0;
            var tempQueue = new Queue<int>();
            if (!visit[0]) tempQueue.Enqueue(0);
            while (true)
            {
                int count = tempQueue.Count;
                if (count == 0) return -1;
                for (int iC = 0; iC < count; ++iC)
                {
                    int now = tempQueue.Dequeue();
                    for (int v = 0; v < 4; v++)
                    {
                        var test = now - now % Math.Pow(10, v + 1) + now % Math.Pow(10, v);
                        int change = (int)(test + (now - test + Math.Pow(10, v)) % Math.Pow(10, v + 1));
                        if (change == targeti) return ++temDepth;
                        if (!visit[change])
                        {
                            visit[change] = true;
                            tempQueue.Enqueue(change);
                        }
                        change = (int)(test + (now - test - Math.Pow(10, v) + Math.Pow(10, v + 1)) % Math.Pow(10, v + 1));
                        if (change == targeti) return ++temDepth;
                        if (!visit[change])
                        {
                            visit[change] = true;
                            tempQueue.Enqueue(change);
                        }
                    }
                }
                temDepth++;
            }
        }
    }
}