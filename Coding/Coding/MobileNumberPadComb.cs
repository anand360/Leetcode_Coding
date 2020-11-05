using System;
using System.Collections.Generic;

public class MobileNumberPadComb
{
    public static List<string> Run(string s){
        if(string.IsNullOrWhiteSpace(s)){
            return null;
        }

        var res = new List<string>();
        var mapping = new string[] {
            "0",
            "1",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
        };

        RecurNumberPadComb(res, s, "", 0, mapping);
        return res;
    }

    private static void RecurNumberPadComb(List<string> res, string s, string cur, int i, string[] mapping)
    {
        if(i == s.Length){
            res.Add(cur);
            return;
        }

        var curstr = mapping[s[i] - '0'];
        for (int j = 0; j < curstr.Length; j++)
        {
            RecurNumberPadComb(res, s, cur + curstr[j], i + 1, mapping);
        }
    }
}