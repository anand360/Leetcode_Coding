using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class ReversetoMakeEqual
    {
        public static bool Run(int[] a, int[]b)
        {
            if(a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var aDict = new Dictionary<int, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (aDict.ContainsKey(a[i]))
                {
                    aDict[a[i]]++;
                }
                else
                {
                    aDict.Add(a[i], 1);
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!aDict.ContainsKey(b[i]))
                {
                    return false;
                }
                else
                {
                    aDict[b[i]]--;
                    if(aDict[b[i]] == 0)
                    {
                        aDict.Remove(b[i]);
                    }
                }
            }

            return aDict.Count == 0;
        }
    }
}
