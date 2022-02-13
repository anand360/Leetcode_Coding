
// https://leetcode.com/problems/generate-parentheses/

using System;
using System.Collections.Generic;
using System.Text;

public class GenerateParenthesis
{
    public IList<string> Run(int n)
    {
        if (n < 1)
        {
            return null;
        }

        var ans = new List<string>();
        BackTrack(ans, new StringBuilder(), 0, 0, n);
        // Approach 2: DFS(n, n, "", ans);

        return ans;
    }

    /* Approach 2:
    private void DFS(int open, int close, string cur, List<string> ans)
    {
        if (open < 0 || close < 0 || open > close)
            return;
        
        if(open == 0 && close == 0)
        {
            ans.Add(cur.ToString());
            return;
        }

        DFS(open-1, close, cur + "(", ans);
        DFS(open, close-1, cur + ")", ans);
    }
    */
    
    private void BackTrack(List<string> ans, StringBuilder cur, int open, int close, int max)
    {
        if (cur.Length == max * 2)
        {
            ans.Add(cur.ToString());
            return;
        }

        if (open < max)
        {
            cur.Append("(");
            BackTrack(ans, cur, open + 1, close, max);
            cur.Remove(cur.Length - 1, 1);
        }

        if (close < open)
        {
            cur.Append(")");
            BackTrack(ans, cur, open, close + 1, max);
            cur.Remove(cur.Length - 1, 1);
        }
    }
}