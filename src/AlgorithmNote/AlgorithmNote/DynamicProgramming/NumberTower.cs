﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmNote
{
    public class NumberTower
    {
        /// <summary>
        /// 120. Triangle, https://leetcode.com/problems/triangle/
        /// 从下到上计算，最下面一层为边界
        /// </summary>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var n = triangle.Count();
            var dp = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                dp[n - 1, i] = triangle[n - 1][i];
            }
            for (var i = n - 2; i >= 0; i--)
            {
                for (var j = 0; j < triangle[i].Count(); j++)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
                }
            }
            return dp[0, 0];
        }

        /// <summary>
        /// 64. Minimum Path Sum, https://leetcode.com/problems/minimum-path-sum/
        /// 与120不同在于，这个是矩形，120题是三角形
        /// 第一行dp只能从它左边的元素累加得到，第一列dp只能从它上面的元素累加得到
        /// 第一行第一列的不动，其他的取左边和上边的最小值
        /// </summary>
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0) return 0;
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j > 0)
                        grid[i][j] += grid[i][j - 1];
                    else if (j == 0 && i > 0)
                        grid[i][j] += grid[i - 1][j];
                    else if (i > 0 && j > 0)
                        grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                }
            }
            return grid[m - 1][n - 1];
        }

        /// <summary>
        /// 62. Unique Paths, https://leetcode.com/problems/unique-paths/, Bloomberg
        /// totally same as problem 64.
        /// </summary>
        public int UniquePaths(int m, int n)
        {
            int[,] grid = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        grid[i, j] = 1;
                    else
                        grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
                }
            }
            return grid[m - 1, n - 1];
        }

        /// <summary>
        /// 63. Unique Paths II, https://leetcode.com/problems/unique-paths-ii/, Bloomberg
        /// </summary>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            if (m == 0) return 0;
            var n = obstacleGrid[0].Length;

            var dp = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1) continue;//这句话和62不同，其他都一样
             
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
