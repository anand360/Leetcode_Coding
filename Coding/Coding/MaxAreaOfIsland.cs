// https://leetcode.com/problems/max-area-of-island/

using System;
using System.Collections.Generic;

public class MaxAreaOfIsland
{
    public static int Run(int[][] grid){
        if(grid == null || grid.Length == 0){
            return 0;
        }
        
        var max = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                var s = new Stack<Tuple<int,int>>();
                if(grid[i][j] == 1){
                    DFSUtil(grid, s, i, j);
                    // int areaCount = DFSUtil(grid, 0, i, j); // Witout stack
                    max = Math.Max(max, s.Count);
                }
            }
        }

        return max;
    }

    private static void DFSUtil(int[][] grid, Stack<Tuple<int, int>> s, int i, int j)
    {
        if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != 1) return;

        s.Push(new Tuple<int, int>(i,j));
        grid[i][j] = 0;

        DFSUtil(grid, s, i-1, j);
        DFSUtil(grid, s, i+1, j);
        DFSUtil(grid, s, i, j-1);
        DFSUtil(grid, s, i, j+1);
    }

    private int DFSUtil(int[][] grid, int area, int i, int j)
    {
        if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != 1) 
        {
            return area;
        }

        area++;
        grid[i][j] = 0;

        area = DFSUtil(grid, area, i-1, j);
        area = DFSUtil(grid, area, i+1, j);
        area = DFSUtil(grid, area, i, j-1);
        area = DFSUtil(grid, area, i, j+1);
        
        return area;
    }
}