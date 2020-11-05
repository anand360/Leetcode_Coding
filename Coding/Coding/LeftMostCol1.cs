// Matrix each row containing 0/1 sorted, Find the smallest column having 1

public class LeftMostCol1
{
    public static int Run(int[,] arr){
        if(arr == null){
            return -1;
        }

        int r = arr.GetLength(0)-1;
        int c = arr.GetLength(1)-1;
        int res = -1;
        while (r >=0 && c>= 0)
        {
            if(arr[r,c] == 1){
                res =c;
                c--;
            }else{
                r--;
            }
        }

        return res;
    }
}