using System;

public class MaximalSquare
{
    public static int Run(char[][] matrix)
    {
        if (matrix == null)
        {
            return 0;
        }

        int r = matrix.Length;
        int c = matrix[0].Length;

        var dp = new int[c + 1];
        int prev = 0;
        int max = 0;
        for (int i = 1; i <= r; i++)
        {
            for (int j = 1; j <= c; j++)
            {
                int t = dp[j];
                if (matrix[i - 1][j - 1] == '1')
                {
                    dp[j] = Math.Min(dp[j-1], Math.Min(prev, dp[j])) + 1;
                    max = Math.Max(max, dp[j]);
                }
                else
                {
                    dp[j] = 0;
                }

                prev = t;
            }
        }

        return max*max;
    }
}