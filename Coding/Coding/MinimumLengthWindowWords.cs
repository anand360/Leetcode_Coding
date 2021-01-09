using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MinimumLengthWindowWords
{
    public static int Run(string text, List<string> words)
    {
        if (text == null || words == null || text.Length == 0 || words.Count == 0)
        {
            return -1;
        }

        var parseText = text.Replace(".", "").Replace(",","").Split(" ").ToList();

        var wordMap = new Dictionary<string, int>();
        foreach (var item in words)
        {
            wordMap.Add(item, -1);
        }

        int count = 0;
        int min_len = int.MaxValue;
        int l_start = 0;
        int l_end = 0;

        for (int i = 0; i < parseText.Count; i++)
        {
            if(wordMap.ContainsKey(parseText[i])){
                if(wordMap[parseText[i]] == -1){
                    count++;
                }

                wordMap[parseText[i]] = i;

                if(count == wordMap.Count){
                    int min = int.MaxValue;
                    foreach (var item in wordMap)
                    {
                        if(min > item.Value){
                            min = item.Value;
                        }
                    }

                    int s = i - min;
                    if(min_len > s){
                        l_start = min;
                        l_end = i;
                        min_len = s;
                    }
                }
            }
        }

        // var pText = text.Split(" ");
        // var minString = new StringBuilder();
        // for (int i = l_start; i <= l_end; i++)
        // {
        //     minString.Append(pText[i]+ " ");
        // }

        // System.Console.WriteLine($"Min substring: {minString.ToString()}");
        return min_len;
    }

    public static int MinWindowLength(string text, List<string> words)
    {
        if(words == null || words.Count == 0){
            return -1;
        }

        
        var parseText = text.ToLower().Replace(".", "").Replace(",","").Split(" ").ToList();

        var textMap = new Dictionary<string, int>();
        var wordMap = new Dictionary<string, int>();
        
        int start =0;
        int s_index = -1;
        int min_len = int.MaxValue;

        for (int i = 0; i < words.Count; i++)
        {
            if(wordMap.ContainsKey(words[i])){
                wordMap[words[i]]++;
            }else{
                wordMap.Add(words[i], 1);
            }
        }

        int count = 0;
        for (int j = 0; j < parseText.Count; j++)  
        {
            if(textMap.ContainsKey(parseText[j])){
                textMap[parseText[j]]++;
            }else{
                textMap.Add(parseText[j], 1);
            }

            if(wordMap.ContainsKey(parseText[j]) && textMap[parseText[j]] <= wordMap[parseText[j]]){
                count++;  //  
            }

            if(count == words.Count){
                while(!wordMap.ContainsKey(parseText[start])){
                    start++;
                }

                while (!wordMap.ContainsKey(parseText[start]) || textMap[parseText[start]] > wordMap[parseText[start]])
                {
                    if(!wordMap.ContainsKey(parseText[start])){
                        start++;
                    }
                    else if(textMap[parseText[start]] > wordMap[parseText[start]]){
                        textMap[parseText[start]]--;
                        start++;
                    }
                }

                int windowLen = j - start +1;
                if(min_len > windowLen){
                    min_len = windowLen;
                    s_index = start;
                }
            }
        }

        if(s_index == -1){
            return -1;
        }

        var pText = text.Split(" ");
        var substring = new StringBuilder();
        for (int i = s_index; i < s_index+ min_len; i++)
        {
            substring.Append(pText[i]+ " ");
        }

        System.Console.WriteLine($"Substring: {substring.ToString()}, Length: {substring.ToString().Length}");
        return substring.ToString().Length;
    }
}