using System.Collections.Generic;

namespace leetcode.basics
{
    public partial class Solution
    {
        private const char landFlag = '1', waterFlag = '0';

        #region [DFS]
        public int NumIslands_v1(char[][] grid)
        {
            var nr = grid.Length;
            if (nr == 0) return 0;
            var nc = grid[0].Length;

            var tempNumsOfLand = 0;
            for (int iR = 0; iR < nr; ++iR)
            {
                for (int iC = 0; iC < nc; ++iC)
                {
                    if (grid[iR][iC] == waterFlag) continue;

                    ++tempNumsOfLand;
                    dfs(grid, iR, iC);
                }
            }
            return tempNumsOfLand;
        }
        //深度优先遍历 - DFS;
        private void dfs(char[][] grid, int r, int c)
        {
            var nr = grid.Length;
            var nc = grid[0].Length;

            grid[r][c] = waterFlag;

            if (r - 1 >= 0 && grid[r - 1][c] == landFlag) dfs(grid, r - 1, c);
            if (r + 1 < nr && grid[r + 1][c] == landFlag) dfs(grid, r + 1, c);

            if (c - 1 >= 0 && grid[r][c - 1] == landFlag) dfs(grid, r, c - 1);
            if (c + 1 < nc && grid[r][c + 1] == landFlag) dfs(grid, r, c + 1);
        }
        #endregion

        #region [BFS]
        //广度优先遍历 - BFS;
        public int NumIslands_v2(char[][] grid)
        {
            var nr = grid.Length;
            if (nr == 0) return 0;
            var nc = grid[0].Length;

            var tempNumsOfLand = 0;
            for (int iR = 0; iR < nr; ++iR)
            {
                for (int iC = 0; iC < nc; ++iC)
                {
                    if (grid[iR][iC] == waterFlag) continue;

                    ++tempNumsOfLand;

                    grid[iR][iC] = waterFlag;
                    var tempNeighbors = new Queue<Pair<int, int>>();
                    tempNeighbors.Enqueue(new Pair<int, int>(iR, iC));

                    while (tempNeighbors.Count != 0)
                    {
                        var tempItem = tempNeighbors.Dequeue();

                        int tempRow = tempItem.First, tempCol = tempItem.Second;

                        if (tempRow - 1 >= 0 && grid[tempRow - 1][tempCol] == landFlag)
                        {
                            tempNeighbors.Enqueue(new Pair<int, int>(tempRow - 1, tempCol));
                            grid[tempRow - 1][tempCol] = waterFlag;
                        }
                        if (tempRow + 1 < nr && grid[tempRow + 1][tempCol] == landFlag)
                        {
                            tempNeighbors.Enqueue(new Pair<int, int>(tempRow + 1, tempCol));
                            grid[tempRow + 1][tempCol] = waterFlag;
                        }
                        if (tempCol - 1 >= 0 && grid[tempRow][tempCol - 1] == landFlag)
                        {
                            tempNeighbors.Enqueue(new Pair<int, int>(tempRow, tempCol - 1));
                            grid[tempRow][tempCol - 1] = waterFlag;
                        }
                        if (tempCol + 1 < nc && grid[tempRow][tempCol + 1] == landFlag)
                        {
                            tempNeighbors.Enqueue(new Pair<int, int>(tempRow, tempCol + 1));
                            grid[tempRow][tempCol + 1] = waterFlag;
                        }
                    }

                }
            }
            return tempNumsOfLand;
        }
        #endregion

        #region [并查集]

        private sealed class UnionFind
        {
            #region [Fields]
            public int Count;
            public int[] parent;
            public int[] rank;
            #endregion

            #region [Construct]
            public UnionFind(char[][] grid)
            {
                Count = 0;
                var tempM = grid.Length;
                var tempN = grid[0].Length;
                parent = new int[tempM * tempN];
                rank = new int[tempM * tempN];

                for (int i = 0; i < tempM; ++i)
                {
                    for (int j = 0; j < tempN; ++j)
                    {
                        if (grid[i][j] == landFlag)
                        {
                            parent[i * tempN + j] = i * tempN + j;
                            ++Count;
                        }
                        rank[i * tempN + j] = 0;
                    }
                }
            }
            #endregion

            #region [API]
            public int find(int varIdx)
            {
                if (parent[varIdx] != varIdx) parent[varIdx] = find(parent[varIdx]);
                return parent[varIdx];
            }
            public void union(int varX, int varY)
            {
                var tempRootX = find(varX);
                var tempRootY = find(varY);
                if (tempRootX != tempRootY)
                {
                    if (rank[tempRootX] > rank[tempRootY])
                    {
                        parent[tempRootY] = tempRootX;
                    }
                    else if (rank[tempRootX] < rank[tempRootY])
                    {
                        parent[tempRootX] = tempRootY;
                    }
                    else
                    {
                        parent[tempRootY] = tempRootX;
                        rank[tempRootX] += 1;
                    }
                    --Count;
                }
            }
            #endregion
        }

        public int NumIslands_v3(char[][] grid)
        {
            var nr = grid.Length;
            if (nr == 0) return 0;
            var nc = grid[0].Length;

            var tempUnion = new UnionFind(grid);
            for (int iR = 0; iR < nr; ++iR)
            {
                for (int iC = 0; iC < nc; ++iC)
                {
                    if (grid[iR][iC] == waterFlag) continue;

                    grid[iR][iC] = waterFlag;

                    if (iR - 1 >= 0 && grid[iR - 1][iC] == landFlag)
                    {
                        tempUnion.union(iR * nc + iC, (iR - 1) * nc + iC);
                    }
                    if (iR + 1 < nr && grid[iR + 1][iC] == landFlag)
                    {
                        tempUnion.union(iR * nc + iC, (iR + 1) * nc + iC);
                    }

                    if (iC - 1 >= 0 && grid[iR][iC - 1] == landFlag)
                    {
                        tempUnion.union(iR * nc + iC, iR * nc + iC - 1);
                    }
                    if (iC + 1 < nc && grid[iR][iC + 1] == landFlag)
                    {
                        tempUnion.union(iR * nc + iC, iR * nc + iC + 1);
                    }

                }
            }
            return tempUnion.Count;
        }
        #endregion
    }
}