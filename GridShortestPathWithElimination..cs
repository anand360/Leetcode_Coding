using System.Collections.Generic;

public class GridShortestPathWithElimination
{
    public static int Run(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        var dir = new int[,]{
            {-1,0},
            {0,1},
            {1, 0},
            {0,-1}
        };
        int step = 0;
        var seen = new int[m, n];
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { 0, 0, k });

        while (q.Count > 0)
        {
            int size = q.Count;
            while (size > 0)
            {
                var cur = q.Dequeue();
                if (cur[0] == m - 1 && cur[1] == n - 1)
                {
                    return step;
                }

                for (int i = 0; i < 4; i++)
                {
                    var nx = cur[0] + dir[i, 0];
                    var ny = cur[1] + dir[i, 1];

                    if (nx >= 0 && nx < m && ny >= 0 && ny < n)
                    {
                        int elLeft = grid[nx][ny] == 1 ? cur[2] - 1 : cur[2];
                        if (elLeft >= 0 && (seen[nx, ny] == 0 || seen[nx, ny] < elLeft))
                        {
                            seen[nx, ny] = elLeft;
                            q.Enqueue(new int[] { nx, ny, elLeft });
                        }
                    }
                }

                size--;
            }
            ++step;
        }

        return -1;
    }
}