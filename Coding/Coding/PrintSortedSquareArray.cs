using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding
{
    public class PrintSortedSquareArray
    {
        public static int[] Run(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return arr;
            }

            var output = new int[arr.Length];
            int left = 0;
            int right = arr.Length - 1;

            int fillIndex = right;
            while (left <= right)
            {
                if (Math.Abs(arr[left]) > Math.Abs(arr[right]))
                {
                    output[fillIndex] = arr[left] * arr[left];
                    left++;
                    fillIndex--;
                }
                else
                {
                    output[fillIndex] = arr[right] * arr[right];
                    right--;
                    fillIndex--;
                }
            }

            return output;
        }
    }
}
