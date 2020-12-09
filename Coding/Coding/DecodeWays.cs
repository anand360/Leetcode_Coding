using System;

public class DecodeWays{
    public static int Run(string input){
        if(input == null){
            return 0;
        }

        var dp = new int[input.Length + 1];
        dp[0] = 1;
        dp[1] = input[0] != '0' ? 1 : 0;
        int count = dp[1];

        for (int i = 2; i < dp.Length; i++)
        {
            if(input[i-1] != '0'){
                dp[i] += dp[i-1]; 
            }

            if(IsValid(input[i-2], input[i-1])){
                dp[i] += dp[i-2];
            }
        }

        return dp[dp.Length-1];
    }

    private static bool IsValid(char v1, char v2)
    {
        return (v1 == '1' && v2 <='9') || (v1 == '2' && v2 <='6');
    }
}