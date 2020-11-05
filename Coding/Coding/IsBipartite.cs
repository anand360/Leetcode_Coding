using System;
using System.Collections.Generic;

public class IsBipartite
{
    public static bool Run(int[,] g)
    {
        if (g == null)
        {
            return true;
        }

        var colors = new int[g.GetLength(0)];

        for (int i = 0; i < g.GetLength(0); i++)
        {
            if (colors[i] == 0 && !Valid(g, colors, 1, i))
            {
                return false;
            }
        }

        return true;
    }

    private static bool Valid(int[,] g, int[] colors, int color, int i)
    {
        if (colors[i] != 0)
        {
            return colors[i] == color;
        }

        colors[i] = color;

        for (int j = 0; j < g.GetLength(0); j++)
        {
            if (g[i, j] != 0 && !Valid(g, colors, -color, j))
            {
                return false;
            }
        }

        return true;
    }

    public static bool BFSRun(int[,] g)
    {
        if (g == null)
        {
            return true;
        }

        var colors = new int[g.GetLength(0)];

        for (int i = 0; i < g.GetLength(0); i++)
        {
            if (colors[i] == 0 && !BFSRunUtil(g, colors, i))
            {
                return false;
            }
        }

        return true;
    }
    private static bool BFSRunUtil(int[,] g, int[] colors, int src)
    {
        var q = new Queue<int>();
        q.Enqueue(0);

        colors[src] = 1;

        while (q.Count > 0)
        {
            var u = q.Dequeue();

            if (g[u, u] == 1)
            {
                return false;
            }

            for (int i = 0; i < g.GetLength(0); i++)
            {
                if (g[u, i] == 1 && colors[i] == 0)
                {
                    colors[i] = colors[u] * -1;
                    q.Enqueue(i);
                }
                else if (g[u, i] == 1 && colors[i] == colors[u])
                {
                    return false;
                }
            }
        }

        return true;
    }
}