using System;

public class MinEditDistanceWord
{
    public static int Run(string word1, string word2)
    {
        var map = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i <= word1.Length; i++)
        {
            for (int j = 0; j <= word2.Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    map[i, j] = 0;
                }
                else if (i == 0 && j != 0)
                {
                    map[i, j] = j;
                }
                else if (i != 0 && j == 0)
                {
                    map[i, j] = i;
                }
                else if (word1[i - 1] == word2[j - 1])
                {
                    map[i, j] = map[i - 1, j - 1];
                }
                else
                {
                    map[i, j] = 1 + Math.Min(map[i, j - 1], Math.Min(map[i - 1, j - 1], map[i - 1, j]));
                }
            }
        }

        return map[word1.Length, word2.Length];
    }
}