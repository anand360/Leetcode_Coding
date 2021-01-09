using System.Collections.Generic;

public class WildcardPattern{
    public static bool Run(string s, string p){
        if(s == null || p == null){
            return false;
        }

        int n = s.Length;
        int m = p.Length;

        var lookup = new bool[n+1, m+1];
        lookup[0,0] = true;

        for (int j = 1; j <= m; j++)
        {
            if(p[j-1] == '*'){
                lookup[0,j] = lookup[0,j-1];
            }
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if(p[j-1] == '*'){
                    lookup[i,j] = lookup[i,j-1] || lookup[i-1,j];
                }
                else if(p[j-1] == '?' || s[i-1] == p[j-1]){
                    lookup[i,j] = lookup[i-1,j-1];
                }
                else{
                    lookup[i,j] = false;
                }
            }
        }

        return lookup[n,m];
    }

    public static bool Comparison(string str, string pattern) {
        int s = 0, p = 0, match = 0, starIdx = -1;         

        int start = -1;   
        while (s < str.Length){
            if(p >= pattern.Length){
                System.Console.WriteLine(str.Substring(match, s-match));
            }
            // advancing both pointers
            if (p < pattern.Length  && (pattern[p] == '?' || str[s] == pattern[p])){
                s++;
                p++;
            }
            // * found, only advancing pattern pointer
            else if (p < pattern.Length && pattern[p] == '*'){
                starIdx = p;
                match = s;
                p++;
            }
            
           // last pattern pointer was *, advancing string pointer
            else if (starIdx != -1){
                p = starIdx + 1;
                // match++;
                // s = match;
                s++;
            }
           //current pattern pointer is not star, last patter pointer was not *
          //characters do not match
            // else return false;
            else{
                s++;
            }
        }
        
        if(p >= pattern.Length){
            System.Console.WriteLine(str.Substring(match, s-match));
        }

        //check for remaining characters in pattern
        while (p < pattern.Length && pattern[p] == '*')
            p++;
        
        return p == pattern.Length;
    }
}