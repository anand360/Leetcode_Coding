// given pattern F2eb2K and input string Facebook, check if they match.
// F2eb2K -> Facebook = True
// 8 -> Facebook = True
// F10eb2k -> Facccccccccebook = True

using System;

public class i18nPatternMatch
{
    public static bool Run(string input, string pattern)
    {
        if(input == null || pattern == null || input.Length < pattern.Length)
        {
            return false;
        }

        int i = 0;
        int j = 0;
        int curNum =0;

        while (i < input.Length && j < pattern.Length)
        {
            while(j < pattern.Length && Char.IsDigit(pattern[j]))
            {
                curNum = (curNum * 10) + (pattern[j] - '0');
                j++;
            }

            if(curNum == 0)
            {
                if (input[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else if(input[i] != pattern[j])
                {
                    return false;
                }
            }

            while(curNum > 0)
            {
                i++;
                curNum--;
            }
        }

        return i == input.Length;
    }    
}