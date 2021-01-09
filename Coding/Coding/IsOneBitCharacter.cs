// https://leetcode.com/problems/1-bit-and-2-bit-characters/
// if there is only one symbol in array the answer is always true (as last element is 0)
// if there are two 0s at the end again the answer is true no matter what the rest symbols are( ...1100, ...1000,)
// if there is 1 right before the last element(...10), the outcome depends on the count of sequential 1, i.e.
// a) if there is odd amount of 1(10, ...01110, etc) the answer is false as there is a single 1 without pair
// b) if it's even (110, ...011110, etc) the answer is true, as 0 at the end doesn't have anything to pair with


public class IsOneBitCharacter
{
    public static bool Run(int[] bits){
        if(bits == null || bits.Length == 0 || bits[bits.Length-1] == 1){
            return false;
        }

        if(bits.Length >= 2 && bits[bits.Length-1] == 0 && bits[bits.Length - 2] ==0){
            return true;
        }

        int one = 0;
        for (int i = bits.Length - 2; i >= 0 && bits[i] == 1; i--)
        {
            one++;
        }

        return one % 2 == 0;
    }
}