using System.Collections.Generic;
using System.Text;

public class GroupAnagram
{
    public static List<List<string>> Run(List<string> input)
    {
        if (input == null)
        {
            return null;
        }

        var anagramTable = new Dictionary<string, List<string>>();
        foreach (var item in input)
        {
            if (item.Length > 0)
            {
                var charCount = new int[26];
                for (int j = 0; j < item.Length; j++)
                {
                    charCount[item[j] - 'a']++;
                }

                var hash = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    hash.Append($"#{charCount[i]}");
                }

                if (anagramTable.ContainsKey(hash.ToString()))
                {
                    anagramTable[hash.ToString()].Add(item);
                }
                else
                {
                    anagramTable[hash.ToString()] = new List<string> { item };
                }
            }
        }

        var res = new List<List<string>>();
        foreach (var item in anagramTable)
        {
            res.Add(item.Value);
        }

        return res;
    }
}