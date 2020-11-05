// Minimum number of jumps to reach end | Set 2 (O(n) solution)
using System;

public class MinimumJumps
{
    public static int Run(int[] arr){
        if (arr == null || arr.Length == 0)
        {
            return -1;
        }

        int maxReach = arr[0];
        int step = arr[0];
        int jump = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (i == arr.Length - 1)
            {
                return jump;
            }

            maxReach = Math.Max(maxReach, i+arr[i]);

            step--;

            if (step == 0)
            {
                jump++;
                
                if (i >= maxReach)
                {
                    return -1;
                }

                step = maxReach - i;
            }
        }

        return -1;
    }
}