using System;

public class IsAlienSorted
{
    public static bool Run(string[] words, string order)
    {
        if (words == null || words.Length == 0)
        {
            return true;
        }

        var map = new int[26];
        for (int i = 0; i < order.Length; i++)
        {
            map[order[i] - 'a'] = i;
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            string a = words[i];
            string b = words[i + 1];
            bool flag = false;

            for (int j = 0; j < Math.Min(a.Length, b.Length); j++)
            {
                if (a[j] != b[j])
                {
                    if (map[a[j] - 'a'] > map[b[j] - 'a'])
                    {
                        return false;
                    }
                    flag = true;
                    break;
                }
            }

            if(!flag && a.Length > b.Length){
                return false;
            }
        }

        return true;
    }
}