public class FirstMissingPositive
{
    public static int Run(int[] nums){
        if (nums == null || (nums.Length == 1 && nums[0] > 1))
        {
            return 1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            // Swap the number until they are in the right position.
            while (nums[i] >= 1 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1]) {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }
        return nums.Length + 1;
    }
}