// https://leetcode.com/problems/word-ladder

using System.Collections.Generic;

public class WordLadder
{
    public static int Run(string beginWord, string endWord, IList<string> wordList)
    {
        var words = new HashSet<string>();
        foreach (var item in wordList)
        {
            words.Add(item);
        }

        if (!words.Contains(endWord))
        {
            return 0;
        }

        int steps = 1;
        var q = new Queue<string>();
        q.Enqueue(beginWord);

        while (q.Count > 0)
        {
            var len = q.Count;

            for (int i = 0; i < len; i++)
            {
                var word = q.Dequeue();
                for (int s = 0; s < word.Length; s++)
                {
                    var t = word[s];
                    var tWord = word.ToCharArray();
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        tWord[s] = c;
                        var modifyWord = new string(tWord);
                        if (modifyWord.Equals(endWord))
                        {
                            return steps + 1;
                        }
                        else if (words.Contains(modifyWord))
                        {
                            q.Enqueue(modifyWord);
                            words.Remove(modifyWord);
                        }
                    }

                    tWord[s] = t;
                    word = new string(tWord);
                }
            }

            steps++;
        }

        return 0;
    }
}