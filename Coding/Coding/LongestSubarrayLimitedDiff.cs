using System;

public class LongestSubarrayLimitedDiff
{
    public static int Run(int[] nums, int limit)
    {
        if (nums == null)
        {
            return 0;
        }

        var maxDeque = new System.Collections.Generic.LinkedList<int>();
        var minDeque = new System.Collections.Generic.LinkedList<int>();

        int res = 1;

        int l = 0;

        // find the longest subarray for every right pointer by shrinking left pointer
        for (int r = 0; r < nums.Length; ++r)
        {

            // update maxDeque with new right pointer
            while (maxDeque.Count != 0 && maxDeque.Last.Value < nums[r])
            {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(nums[r]);

            // update minDeque with new right pointer
            while (minDeque.Count != 0 && minDeque.Last.Value > nums[r])
            {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(nums[r]);

            // shrink left pointer if exceed limit
            while (maxDeque.First.Value - minDeque.First.Value > limit)
            {
                if (maxDeque.First.Value == nums[l]) maxDeque.RemoveFirst();
                if (minDeque.First.Value == nums[l]) minDeque.RemoveFirst();
                ++l;  // shrink it!
            }

            // update res
            res = Math.Max(res, r - l + 1);
        }

        return res;
    }
}