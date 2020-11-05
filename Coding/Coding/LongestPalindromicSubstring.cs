//https://www.ideserve.co.in/learn/longest-palindromic-substring

public class LongestPalindromicSubstring
{
    public static string Run(string s){
        if(string.IsNullOrWhiteSpace(s)){
            return string.Empty;
        }

        if(s.Length <=1){
            return s[0].ToString();
        }

        if (s.Length == 2)
        {
            if(s[0] == s[1]){
                return s;
            }else{
                return s[0].ToString();
            }
        }

        var d = new bool[s.Length, s.Length];

        var start = 0;
        var max_len = 0;

        for (int i = 0; i < s.Length; i++)
        {
            d[i,i] = true;
            max_len = 1;
        }

        for (int i = 0; i < s.Length - 1; i++)
        {
            if(s[i] == s[i+1]){
                d[i,i+1] = true;
                start = i;
                max_len = 2;
            }
        }
        
        for (int i = 3; i <= s.Length; i++)
        {
            for (int j = 0; j < s.Length - i + 1; j++)
            {
                int k = j+i-1;
                if(s[j] == s[k] && d[j+1, k-1]){
                    d[j,k] = true;
                    start = j;
                    max_len = i;
                }
            }
        }

        return s.Substring(start, max_len);
    }
}