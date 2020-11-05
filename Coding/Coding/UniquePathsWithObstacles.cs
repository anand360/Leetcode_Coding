using System;

public class UniquePathsWithObstacles
{
    public static int Run(int[][] obstacleGrid){
        if(obstacleGrid == null){
            return 0;
        }

        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }

        obstacleGrid[0][0] = 1;

        for (int i = 1; i < obstacleGrid.Length; i++)
        {
            if (obstacleGrid[i][0] == 0)
            {
                obstacleGrid[i][0] = obstacleGrid[i-1][0];                
            }else{
                obstacleGrid[i][0] = 0;
            }
        }

        for (int i = 1; i < obstacleGrid[0].Length; i++)
        {
            if (obstacleGrid[0][i] == 0)
            {
                obstacleGrid[0][i] = obstacleGrid[0][i-1];                
            }else{
                obstacleGrid[0][i] = 0;
            }
        }

        for (int i = 1; i < obstacleGrid.Length; i++)
        {
            for (int j = 1; j < obstacleGrid[0].Length; j++)
            {
                if (obstacleGrid[i][j] == 0)
                {
                    obstacleGrid[i][j] = obstacleGrid[i-1][j] + obstacleGrid[i][j-1];
                }else{
                    obstacleGrid[i][j] = 0;
                }
            }
        }

        return obstacleGrid[obstacleGrid.Length -1][obstacleGrid[0].Length-1];
    }
}

// Solution 2: formula O(n)  Without obstacles
class Solution {
    public int uniquePaths(int m, int n) {
        int N = n + m - 2; // how much steps we need to do
        int k = m - 1; // number of steps that need to go down
        double res = 1;
        // here we calculate the total possible path number 
        // Combination(N, k) = n! / (k!(n - k)!)
        // reduce the numerator and denominator and get
        // C = ( (n - k + 1) * (n - k + 2) * ... * n ) / k!
        for (int i = 1; i <= k; i++) {
            res *= (double)(N - k + i) / (double)i;            
        }

        return (int)Math.Round(res);
    }
} 