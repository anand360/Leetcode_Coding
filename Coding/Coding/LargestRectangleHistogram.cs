using System;
using System.Collections.Generic;

public class LargestRectangleHistogram
{
    public static int Run(int[] heights)
    {
        if (heights == null)
        {
            return 0;
        }

        var s = new Stack<int>();
        int i = 0;
        int max_area = 0;
        while (i < heights.Length)
        {
            if (s.Count == 0 || heights[s.Peek()] <= heights[i])
            {
                s.Push(i);
            }
            else
            {
                var tp = s.Peek();
                s.Pop();
                var a = heights[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);
                max_area = Math.Max(max_area, a);
            }
            i++;
        }

        while (s.Count > 0)
        {
            var tp = s.Peek();
            s.Pop();
            var a = heights[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);
            max_area = Math.Max(max_area, a);
        }

        return max_area;
    }
}