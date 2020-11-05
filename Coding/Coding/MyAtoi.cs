
/*
Handling overflow and underflow conditions
If the integer is positive, for 32 bit signed integer, \text{INT\_MAX}INT_MAX is 2147483647 (2^{31}-1)2147483647(2^31 −1) To avoid integer overflow, we must ensure that it doesn't exceed this value. This condition needs to be handled when the result is greater than or equal to \frac{\text{INT\_MAX}}{10} 
10 INT_MAX​	 (214748364)Case 1). If \text{result} = \frac{\text{INT\_MAX}}{10}result= 
10
INT_MAX​	
 , it would result in integer overflow if next integer character is greater than 7. (7 in this case is last digit of \text{INT\_MAX} (2147483647)INT_MAX(2147483647)). We can use \text{INT\_MAX} \% 10INT_MAX%10 to generically represent the last digit.

Case 2). If \text{result} > \frac{\text{INT\_MAX}}{10}result> 
10
INT_MAX
​	
 , we are sure that adding next number would result in integer overflow.

This holds for negative integer as well. In the 32-bit integer, \text{INT\_MIN}INT_MIN value is -2147483648 (-2^{31})−2147483648(−2 
31
 ). As the last digit is greater than 7 (\text{INT\_MAX} \% 10INT_MAX%10), integer underflow can also be handled using the above approach.
*/
public class MyAtoi
{
    public static int Run(string str){
        if(string.IsNullOrWhiteSpace(str) || char.IsLetter(str[0])){
            return 0;
        }

        int i = 0;
        int res = 0;
        while (i < str.Length && str[i] == ' ')
        {
            i++;
        }

        if (char.IsLetter(str[i]))
        {
            return 0;
        }
        
        bool isNeg = false;
        if (str[i] == '-')
        {
            isNeg = true;
            i++;
        }else if(str[i] == '+'){
            isNeg = false;
            i++;
        }

        while (i < str.Length && char.IsDigit(str[i]))
        {
            if (res > int.MaxValue/10 || (res == int.MaxValue/10 && (str[i] - '0') > int.MaxValue % 10))
            {
                return isNeg ? int.MinValue : int.MaxValue;
            }
            res = res * 10 + (str[i] - '0');
            
            i++;
        }

        return isNeg ? -1 * res : res;
    }
}