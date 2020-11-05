using System;

public class Divide
{
    public static int Run(int dividend, int divisor)
    {
        if (dividend == 0)
        {
            return 0;
        }

        if (dividend == divisor)
        {
            return 1;
        }

        if (dividend == int.MinValue && divisor < 0)
        {
        }

        int res = 0;
        int sign = dividend < 0 && divisor < 0 ? 1 : (dividend < 0 || divisor < 0) ? -1 : 1;
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);
        while (dividend >= divisor)
        {
            dividend -= divisor;
            res++;
        }

        return sign * res;
    }
}