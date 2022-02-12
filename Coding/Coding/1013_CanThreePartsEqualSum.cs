// https://leetcode.com/problems/partition-array-into-three-parts-with-equal-sum/

public class CanThreePartsEqualSum
{
    public static bool Run(int[] A)
    {
        if (A == null)
        {
            return false;
        }

        var sum = 0;
        for (int j = 0; j < A.Length; j++)
        {
            sum += A[j];
        }

        if (sum % 3 != 0)
        {
            return false;
        }

        var oneSum = sum / 3;
        var subSum = 0;
        int count = 0;
        int i = 0;
        for (i = 0; i < A.Length && count < 2; i++)
        {
            subSum += A[i];

            if (oneSum == subSum)
            {
                count++;
                subSum = 0;
            }
        }

        if (count == 2 && i < A.Length)
        {
            for (; i < A.Length; i++)
            {
                subSum += A[i];
            }
            
            return oneSum == subSum ? true : false;
        }
        else
        {
            return false;
        }
    }
}