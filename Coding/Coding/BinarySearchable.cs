// https://leetcode.com/discuss/interview-question/352743/Google-or-Onsite-or-Guaranteed-Binary-Search-Numbers
using System;
using System.Collections.Generic;

public class BinarySearchable
{
    public static int Run(int[] input){
        if(input == null || input.Length == 0){
            return -1;
        }

        var searchable = new Stack<int>();
        searchable.Push(0);
        int max = input[0];

        for (int i = 1; i < input.Length; i++)
        {
            if(input[i] > max){
                searchable.Push(i);
                max = input[i];
            }
            else{
                while(searchable.Count > 0 && input[searchable.Peek()] > input[i]){
                    searchable.Pop();
                }
            }
        }

        return searchable.Count;
    }

    public static int UsingMaxArray(int[] input){
        if(input == null || input.Length == 0){
            return -1;
        }

        int count = 0;
        var leftMax = new int[input.Length];
        leftMax[0] = input[0];

        for (int i = 1; i < input.Length; i++)
        {
            leftMax[i] = Math.Max(leftMax[i-1], input[i]);
        }

        int rightMin = int.MaxValue;

        for (int i = input.Length - 1; i >= 0; i--)
        {
            rightMin = Math.Min(rightMin, input[i]);
            if(input[i] >= leftMax[i] && input[i] <= rightMin){
                count++;
            }
        }

        return count;
    }
}