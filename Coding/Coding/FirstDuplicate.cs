using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    // given array has elments from 1-> N (size of array)
    public class FirstDuplicate
    {
        public static int Run(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 1 && arr[i] > arr.Length - 1)
                {
                    continue;
                }

                if(arr[Math.Abs(arr[i]) - 1] < 0)
                {
                    return arr[i];
                }

                arr[Math.Abs(arr[i]) - 1] *= -1;
            }

            return -1;
        }
    }
}
