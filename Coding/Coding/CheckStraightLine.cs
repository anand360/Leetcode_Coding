// https://leetcode.com/problems/check-if-it-is-a-straight-line/
// (y2 - y1)(x3 - x1) == (x2 - x1)(y3 - y1)  slope should be equal.

using System;

public class CheckStraightLine
{
    public static bool Run(int[][] coordinates)
    {
        if (coordinates == null)
        {
            return false;
        }
        if (coordinates.Length <= 2)
        {
            return true;
        }

        for (int i = 2; i < coordinates.Length; i++)
        {
            var a = ((coordinates[1][0] - coordinates[0][0]) * (coordinates[i][1] - coordinates[0][1]))
                !=
                ((coordinates[1][1] - coordinates[0][1]) * (coordinates[i][0] - coordinates[0][0]));
            if (a)
            {
                return false;
            }
        }

        return true;
    }
}