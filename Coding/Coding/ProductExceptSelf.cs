public class ProductExceptSelf
{
    public static int[] Run(int[] nums){
        if(nums == null){
            return null;
        }

        var res = new int[nums.Length];
        res[0] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            res[i] = nums[i-1] * res[i-1];
        }

        int r = 1;

        for (int i = nums.Length -1 ; i >= 0; i--)
        {
            res[i] = res[i] * r;
            r = r * nums[i];
        }

        return res;
    }
}