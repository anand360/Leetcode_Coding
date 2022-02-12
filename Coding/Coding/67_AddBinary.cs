// https://leetcode.com/problems/add-binary/

public class AddBinary
{
    public static string Run(string a, string b)
    {
        if (a == "0")
        {
            return b;
        }

        if (b == "0")
        {
            return a;
        }

        int ai = a.Length - 1;
        int bi = b.Length - 1;

        int s = 0;
        string res = string.Empty;
        while (ai >= 0 || bi >= 0 || s == 1)
        {
            s += ai >= 0 ? a[ai] - '0' : 0;
            s += bi >= 0 ? b[bi] - '0' : 0;

            res = (char)(s%2 - '0') + res;

            s /= 2;
            ai--;
            bi--;
        }

        return res;
    }
}