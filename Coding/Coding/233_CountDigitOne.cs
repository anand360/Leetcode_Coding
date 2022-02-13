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

// public int countDigitOne(int n) {

//     if (n <= 0) return 0;
//     int q = n, x = 1, ans = 0;
//     do {
//         int digit = q % 10;
//         q /= 10;
//         ans += q * x;
//         if (digit == 1) ans += n % x + 1;
//         if (digit >  1) ans += x;
//         x *= 10;
//     } while (q > 0);
//     return ans;

// }

/*
 public int countDigitOne(int n) {
        int memory = 0;
        int residue = 0;
        int base = 1;
        int count = 0;
        while(n > 0) {
            int t = n % 10;
            if(t > 1) count += t * memory + base;
            else if(t == 1) count += memory + residue + 1;
            residue += t * base;
            n /= 10;
            memory = 10 * memory + base;
            base *= 10;
        }
        return count;
    }
*/