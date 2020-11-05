using System.Collections.Generic;

public class TwoSum
{
    public static int[] Run(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        var map = new Dictionary<int, int>();
        var res = new int[2];

        for (int i = 0; i < nums.Length; i++)
        {
            var sub = target - nums[i];
            if (map.ContainsKey(sub))
            {
                res[0] = map[sub];
                res[1] = i;

                return res;
            }

            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        return res;
    }
}