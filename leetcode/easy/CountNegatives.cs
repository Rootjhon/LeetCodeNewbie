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
    }
}
