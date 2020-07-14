namespace leetcode
{
    public partial class Solution
    {
        public int CountNegatives_v0(int[][] grid)
        {
            var tempCount = 0;
            for (int iR = 0; iR < grid.Length; ++iR)
            {
                var tempRow = grid[iR];
                for (int iC = 0; iC < tempRow.Length; ++iC)
                {
                    if (tempRow[iC] < 0)
                    {
                        tempCount++;
                    }
                }
            }
            return tempCount;
        }

        public int CountNegatives_v1(int[][] grid)
        {
            var tempCount = 0;
            var tempNegaRaw = grid.Length;
            var tempNegaCol = grid[0].Length;
            for (int iR = 0; iR < tempNegaRaw; ++iR)
            {
                var tempRow = grid[iR];
                for (int iC = 0; iC < tempNegaCol; ++iC)
                {
                    if (tempRow[iC] < 0)
                    {
                        tempCount += (grid.Length - iR) * (tempNegaCol - iC);
                        tempNegaCol = iC;
                        break;
                    }
                }
            }
            return tempCount;
        }

        public int CountNegatives_v2(int[][] grid)
        {
            int num = 0;
            for (int i = 0; i < grid.Length; ++i)
            {
                int tempBegin = 0, tempEnd = grid[i].Length, pos = -1;
                while (tempBegin <= tempEnd)
                {
                    int tempMid = tempBegin + ((tempEnd - 1) >> 1);
                    if (grid[i][tempMid] < 0)
                    {
                        pos = tempMid;
                        tempEnd = tempMid - 1;
                    }
                    else
                    {
                        tempBegin = tempMid + 1;
                    }
                    if (~pos != 0)
                    {
                        // pos=-1表示这一行全是>=0的数，不能统计
                        num += grid[i].Length - pos;
                    }
                }
            }
            return num;
        }
    }
}
