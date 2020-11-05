// "3[a2[c]]"

using System;
using System.Collections.Generic;

public class DecodeString
{
    public static string Run(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return s;
        }
        int pos = 0;
        return GetString(s, ref pos);
    }

    private static string GetString(string s, ref int v)
    {
        int num = 0;
        string word = string.Empty;
        for (; v < s.Length; v++)
        {
            char cur = s[v];
            if (cur == '[')
            {
                v = v +1;
                var curStr = GetString(s, ref v);
                while (num > 0)
                {
                    word += curStr;
                    num--;
                }
            }
            else if (char.IsDigit(cur))
            {
                num = num * 10 + (cur - '0');
            }
            else if (cur == ']')
            {
                return word;
            }
            else{
                word += cur;
            }
        }

        return word;
    }
}