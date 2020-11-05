using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class PassingYearbooks
    {
        public static int[] Run(int[] a, int n)
        {
            if (a == null || n != a.Length)
            {
                return new int[] { };
            }

            var map = new Dictionary<int, int>();
            var output = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                map.Add(a[i], i);
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (map.ContainsKey(i + 1))
                {
                    var cindex = map[i+1];
                    if(cindex == i)
                    {
                        output[i] = 1;
                    }
                    else if(cindex < i)
                    {
                        output[i] = 1 + i - cindex;
                    }
                    else
                    {
                        output[i] = 1 + (n - cindex) + (i);
                    }
                }
            }

            return output;
        }
    }
}
