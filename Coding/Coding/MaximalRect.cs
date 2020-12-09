using System;
using System.Collections;
using System.Collections.Generic;

public class MaximalRect
{
    public static int Run(char[][] matrix)
    {
        if(matrix == null){
            return 0;
        }

        var r = matrix.Length;
        if (r == 0)
        {
            return 0;
        }

        var c = matrix[0].Length;

        var h = new int[c + 1];
        var max = 0;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (matrix[i][j] == '1')
                {
                    h[j]++;
                }
                else
                {
                    h[j] = 0;
                }
            }

            max = Math.Max(max, MaxArea(h));
        }

        return max;
    }

    private static int MaxArea(int[] h)
    {
        int max = 0;
        var s = new Stack<int>();
        
        for (int i = 0; i < h.Length; i++)
        {
            while(s.Count > 0 && h[s.Peek()] > h[i]){
                int index = s.Pop();

                int left = -1;
                if(s.Count > 0){
                    left = s.Peek();
                }

                max = Math.Max(max, h[index] * (i - left - 1));
            }

            s.Push(i);            
        }

        return max;
    }
}