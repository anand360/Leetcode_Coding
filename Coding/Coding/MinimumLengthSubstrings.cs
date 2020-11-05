using System;
using System.Collections.Generic;
using System.Text;

namespace Coding
{
    public class MinimumLengthSubstrings
    {
        public static int Run(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t) || s.Length < t.Length)
            {
                return 0;
            }

            var tmap = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (!tmap.ContainsKey(t[i]))
                {
                    tmap.Add(t[i], 1);
                }
                else
                {
                    tmap[t[i]]++;
                }
            }

            int l = 0;
            int start_index = -1;
            int count = 0;
            int min_len = int.MaxValue;
            for (int i = 0; i < s.Length; i++)
            {
                if (tmap.ContainsKey(s[i]))
                {
                    tmap[s[i]]--;
                    if (tmap[s[i]] >= 0)
                    {
                        count++;
                    }

                    while (count == t.Length)
                    {
                        if (i - l + 1 < min_len)
                        {
                            min_len = i - l + 1;
                            start_index = l;
                        }
                        if (tmap.ContainsKey(s[l]))
                        {
                            tmap[s[l]]++;
                            if (tmap[s[l]] > 0)
                            {
                                count--;
                            }
                        }
                        l++;
                    }
                }
            }
            // s.Substring(start_index, min_len);
            if (min_len > s.Length)
            {
                return 0;
            }
            return start_index != -1 ? min_len : start_index;
        }
    }
}
