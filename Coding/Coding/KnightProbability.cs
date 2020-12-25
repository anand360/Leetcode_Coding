// https://leetcode.com/problems/knight-probability-in-chessboard/
using System.Collections.Generic;

public class KnightProbability
{
    public static double Run(int N, int K, int r, int c)
    {
        var dir = new int[,]{
            {-2, -1},
            {-2, 1},
            {-1,2},
            {1, 2},
            {2,1},
            {2,-1},
            {1,-2},
            {-1,-2}
        };
        var dp1 = new double[N, N];
        dp1[r, c] = 1;

        for (; K > 0; K--)
        {
            var dp2 = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int u = 0; u < dir.GetLength(0); u++)
                    {
                        int rr = i + dir[u, 0];
                        int cc = j + dir[u, 1];
                        if (rr >= 0 && rr < N && cc >= 0 && cc < N)
                        {
                            dp2[rr, cc] += dp1[i, j] / 8.0;
                        }
                    }
                }
            }

            dp1 = dp2;
        }

        double ans = 0.0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                ans += dp1[i, j];
            }
        }

        return ans;
    }
}