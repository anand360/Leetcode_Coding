//"bacabcbb"

using System.Collections.Generic;

public class LengthOfLongestSubstring
{
    public static int Run(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        if (s == " ")
        {
            return 1;
        }

        var map = new Dictionary<char, int>();
        int max_len = int.MinValue;
        int l = 0;
        int r = 0;
        while (r < s.Length)
        {
            if (!map.ContainsKey(s[r]))
            {
                map.Add(s[r], r);
                if (max_len < r - l + 1)
                {
                    max_len = r - l + 1;
                }
            }
            else
            {
                if (map[s[r]] + 1 > l )
                {
                    l = map[s[r]] + 1;
                }
                
                map[s[r]] = r;
                if (max_len < r - l + 1)
                {
                    max_len = r - l + 1;
                }
            }

            r++;
        }

        return max_len;
    }
}