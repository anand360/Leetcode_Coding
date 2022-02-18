/* Given a stream of int array
nums = [1,1,3,4,2,8,6,12,11]
Print the minimum represtation of array i.e. range array.
output= [[1,4], [6,6], [8,8], [11,12]]
*/
// Need to implement.

using System.Collections.Generic;

public class PrintRangeArray
{
    public IList<int[]> Run(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        IList<int[]> result = new List<int[]>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (result.Count == 0)
            {
                result.Add(new int[] { nums[i], nums[i] });
            }
            else
            {
                var placeIndex = GetPlaceIndex(result, nums[i]);

                if (placeIndex == 0)
                {
                    if (result[placeIndex][0] == nums[i] || result[placeIndex][0] == nums[i] + 1)
                    {
                        result[placeIndex][0] = nums[i];
                    }

                    if (result[placeIndex][1] == nums[i] || result[placeIndex][1] == nums[i] - 1)
                    {
                        result[placeIndex][1] = nums[i];
                    }
                    else
                    {
                        var newItem = new int[]{nums[i], nums[i]};
                        
                    }
                }
                else
                {
                    if (result[placeIndex - 1][1] == nums[i] - 1)
                    {

                    }
                }
            }
        }

        return result;
    }

    private int GetPlaceIndex(IList<int[]> result, int n)
    {
        int l = 0;
        int r = result.Count - 1;

        while (l <= r)
        {
            int mid = (r + l) / 2;

            if (result[mid][0] == n)
            {
                return mid;
            }

            if (n < result[mid][0])
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return l;
    }
}