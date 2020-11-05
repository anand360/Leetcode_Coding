using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class ContiguousSubarrays
    {
        public static int[] Run(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                return a;
            }

            var left = new int[a.Length];
            var right = new int[a.Length];
            var output = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                int c = i;
                output[i] = 1;
                while (c > 0 && a[c - 1] < a[i])
                {
                    output[i]++;
                    c--;
                }

                c = i;
                while (c < a.Length -1 && a[i] > a[c+1])
                {
                    output[i]++;
                    c++;
                }
            }

            return output;
        }
    }

    //int[] countSubarrays(int[] arr)
    //{
    //    // Write your code here
    //    Stack<Integer> s = new Stack<>();
    //    int[] L = new int[arr.length];
    //    L[0] = 1;
    //    s.push(0);
    //    for (int i = 1; i < arr.length; i++)
    //    {
    //        while (!s.isEmpty() && arr[s.peek()] < arr[i]) s.pop();
    //        if (s.isEmpty()) L[i] = i + 1;
    //        else L[i] = i - s.peek();
    //        s.push(i);
    //    }
    //    int[] R = new int[arr.length];
    //    R[arr.length - 1] = L[arr.length - 1];
    //    s.clear();
    //    s.push(arr.length - 1);
    //    for (int i = arr.length - 2; i >= 0; i--)
    //    {
    //        while (!s.isEmpty() && arr[s.peek()] < arr[i]) s.pop();
    //        if (s.isEmpty()) R[i] = (arr.length - i) + L[i] - 1;
    //        else R[i] = (s.peek() - i) + L[i] - 1;
    //        s.push(i);
    //    }
    //    return R;
    //}
}
