// nested-list-weight-sum/
// https://leetcode.com/problems/nested-list-weight-sum/

using System.Collections;
using System.Collections.Generic;

public class NestedListWeightSum
{
    public static int Run(ArrayList arr)
    {
        if (arr == null || arr.Count == 0)
        {
            return 0;
        }

        return GetSum(arr, 1);
    }

    private static int GetSum(object array, int depth)
    {
        if (array == null)
        {
            return 0;
        }

        int sum = 0;
        if (array is int)
        {
            sum += depth * (int)array;
        }
        else
        {
            foreach (var item in (ArrayList)array)
            {
                if (item is int)
                {
                    sum += depth * (int)item;
                }
                else
                {
                    sum += GetSum(item, depth + 1);
                }
            }
        }

        return sum;
    }
}