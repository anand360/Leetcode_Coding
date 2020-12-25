// https://leetcode.com/problems/max-points-on-a-line/
// another solution: https://github.com/fishercoder1534/Leetcode/blob/master/src/main/java/com/fishercoder/solutions/_149.java

using System;
using System.Collections.Generic;

public class StraightLineMaxPoints
{
    public static int Run(int[][] points)
    {
        if (points == null)
        {
            return 0;
        }

        if (points.Length <= 2)
        {
            return points.Length;
        }

        var map = new Dictionary<string, int>();

        int result = 0;

        for (int i = 0; i < points.Length; i++)
        {
            int same = 0;
            int localMax = 0;
            for (int j = i + 1; j < points.Length; j++)
            {
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];
                if (dx == 0 && dy == 0)
                {
                    same++;
                }
                else
                {
                    var slope = GetSlope(dx, dy);
                    if (map.ContainsKey(slope))
                    {
                        map[slope]++;
                    }
                    else
                    {
                        map.Add(slope, 1);
                    }

                    localMax = Math.Max(localMax, map[slope]);
                }
            }

            result = Math.Max(result, localMax + same + 1);
            map.Clear();
        }

        return result;
    }

    private static int GCD(int a, int b)
    {
        if(b == 0) return a;
        return GCD(b, a%b);
    }

    private static string GetSlope(int dx, int dy)
    {
        if (dx == 0) return 1+"-"+0;
        if (dy == 0) return 0+"-"+1;
        int d = GCD(dx,dy);
        return dx/d+"-"+dy/d;
    }
}