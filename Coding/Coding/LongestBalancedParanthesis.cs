using System;
using System.Collections.Generic;

public class LongestBalancedParanthesis{
    public static int Run(string input){
        if(input == null || input.Length == 1){
            return -1;
        }

        int maxLen = 0;
        var s = new Stack<int>();
        s.Push(-1);
        for (int i = 0; i < input.Length; i++)
        {
            if(input[i] == '('){
                s.Push(i);
            }
            else{
                if(s.Count > 0)
                s.Pop();

                if(s.Count > 0){
                    maxLen = Math.Max(maxLen, i - s.Peek());
                }else{
                    s.Push(i);
                }
            }
        }

        return maxLen;
    }
}