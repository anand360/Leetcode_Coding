using System;
using System.Collections;
using System.Collections.Generic;

public class IntervalComparator : IComparer<int[]>
{
    public int Compare(int[] x, int[] y)
    {
        return x[0] < y[0] ? -1 : x == y ? 0 : 1;
    }
}

public class MergeIntervals
{
    public static int[][] Run(int[][] intervals){
        if(intervals == null){
            return intervals;
        }

        Array.Sort(intervals, new IntervalComparator());

        var intervalArr = new List<int[]>();

        for (int i = 0; i < intervals.GetLength(0); i++)
        {
            if (intervalArr.Count == 0 || intervalArr[intervalArr.Count - 1][1] < intervals[i][0])
            {
                intervalArr.Add(new int[]{intervals[i][0], intervals[i][1]});
            }else{
                intervalArr[intervalArr.Count - 1][1] = Math.Max(intervalArr[intervalArr.Count - 1][1], intervals[i][1]);
            }
        }

        var res = new int[intervalArr.Count][];
        for (int i = 0; i < intervalArr.Count; i++)
        {
            res[i] = new int[]{ intervalArr[i][0], intervalArr[i][1]};
        }

        return res;
    }
}