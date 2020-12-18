//https://leetcode.com/problems/shortest-bridge/
// Perform DFS to find first island and then BFS to find first island border by check 1.

using System;
using System.Collections.Generic;

public class ShortestBridge{
    public static int Run(int[][] A){
        if(A == null || A.Length == 0){
            return -1;
        }        

        var visited = new bool[A.Length, A[0].Length];
        var q = new Queue<Tuple<int, int>>();

        for (int i = 0; i < A.Length; i++)
        {
            if(q.Count > 0){
                break;
            }
            for (int j = 0; j < A[0].Length; j++)
            {
                if(A[i][j] == 1){
                    DFSUtil(A, visited, q, i, j);
                    break;
                }
            }
        }

        var minSteps = BFSUtil(A, visited, q);

        return minSteps;
    }

    private static int BFSUtil(int[][] a, bool[,] visited, Queue<Tuple<int, int>> q)
    {
        if(q== null || q.Count == 0){
            return -1;
        }

        var steps = 0;
        var dir = new int[,]{
            {1,0},
            {-1, 0},
            {0, 1},
            {0, -1}
        };

        while(q.Count > 0){
            var size  = q.Count;

            for (int i = 0; i < size; i++)
            {
                var node = q.Dequeue();
                for (int j = 0; j < dir.GetLength(0); j++)
                {
                    var ix = node.Item1 + dir[j,0];
                    var jx = node.Item2 + dir[j,1];
                    if(ix < 0 || ix >= a.Length || jx < 0 || jx >= a[0].Length || visited[ix,jx]){
                        continue;
                    }
                    if(a[ix][jx] == 1){
                        return steps;
                    }else{
                        q.Enqueue(new Tuple<int, int>(ix, jx));
                        visited[ix,jx] = true;
                    }
                }
            }

            steps++;
        }

        return -1;
    }

    private static void DFSUtil(int[][] a, bool[,] visited, Queue<Tuple<int, int>> q, int i, int j)
    {
        if(i < 0 || i >= a.Length || j < 0 || j >= a[0].Length || visited[i,j] || a[i][j] == 0)
        return;

        if(a[i][j] == 1){
            q.Enqueue(new Tuple<int, int>(i,j));
            visited[i,j] = true;
        }
        
        DFSUtil(a, visited, q, i+1, j);
        DFSUtil(a, visited, q, i-1, j);
        DFSUtil(a, visited, q, i, j+1);
        DFSUtil(a, visited, q, i, j-1);
    }
}