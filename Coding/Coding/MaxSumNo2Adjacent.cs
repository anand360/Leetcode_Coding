using System;

public class MaxSumNo2Adjacent
{
    public static int Run(int[] arr)
    {
        if (arr.Length == 1)
        {
            return arr[0];
        }

        if (arr.Length == 2)
        {
            return Math.Max(arr[0], arr[1]);
        }

        var inl = Math.Max(arr[0], arr[1]);
        var ex = arr[0];

        for (int i = 2; i < arr.Length; i++)
        {
            int t = Math.Max(arr[i], Math.Max(inl, ex + arr[i]));
            ex = inl;
            inl = t;
        }

        return inl;
    }
}