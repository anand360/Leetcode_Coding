
// https://leetcode.com/problems/valid-triangle-number/

using System;

public class TriangleNumber
{
    public int Run(int[] nums)
    {
        if (nums == null || nums.Length < 3)
        {
            return 0;
        }

        Array.Sort(nums);
        int count = 0;

        for (int i = nums.Length - 1; i >= 2; i--)
        {
            int l = 0;
            int r = i - 1;
            while (l < r)
            {
                if (nums[l] + nums[r] > nums[i])
                {
                    count += r - l;
                    r--;
                }
                else
                {
                    l++;
                }
            }
        }

        return count;
    }
}