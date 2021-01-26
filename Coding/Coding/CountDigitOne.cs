// https://leetcode.com/problems/number-of-digit-one/

using System;

public class CountDigitOne
{
    public static int Run(int n){
        if(n <= 0){
            return 0;
        }

        int count = 0;
        for (long i = 1; i <= n; i*=10)
        {
            long div = i * 10;
            count += (int)((n/div) * i + Math.Min(Math.Max(n % div - i + 1, 0), i));
        }

        return count;
    }
}