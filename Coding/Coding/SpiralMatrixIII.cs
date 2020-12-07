// https://leetcode.com/problems/spiral-matrix-iii/
// https://github.com/fishercoder1534/Leetcode/blob/master/src/main/java/com/fishercoder/solutions/_885.java

public class SpiralMatrixIII{
    public static int[][] Run(int R, int C, int r0, int c0){
        int i = r0;
        int j = c0;

        int top = r0;
        int bottom = r0;

        int left  = c0;
        int right = c0;

        int count = 0;

        var res = new int[R*C][];
        res[count++] = new int[]{i,j};

        while (top >= 0 || bottom < R && left >= 0 && right < C)
        {
            j += 1;

            right += 1;
            bottom += 1;
            left -= 1;
            top -= 1;

            while (i < bottom)
            {
                if(0 <= i && i < R && 0<=j && j < C){
                    res[count] = new int[]{i,j};
                    count++;
                }
                i++;
            }

            while (j > left)
            {
                if(0 <= i && i < R && 0<=j && j < C){
                    res[count] = new int[]{i,j};
                    count++;
                }
                j--;
            }

            while (i > top)
            {
                if(0 <= i && i < R && 0<=j && j < C){
                    res[count] = new int[]{i,j};
                    count++;
                }
                i--;
            }
            while (j < right)
            {
                if(0 <= i && i < R && 0<=j && j < C){
                    res[count] = new int[]{i,j};
                    count++;
                }
                j++;
            }

            if(0 <= i && i < R && 0<=j && j < C){
                res[count] = new int[]{i,j};
                count++;
            }
        }

        return res;
    }

    public int[][] spiralMatrixIII(int R, int C, int r0, int c0) {
        int[] directions = new int[]{0, 1, 0, -1, 0};
        int[][] result = new int[R * C][];
        int i = 0;
        result[i++] = new int[]{r0, c0};
        int len = 0;
        int d = 0;
        while (i < R * C) {
            if (d == 0 || d == 2) {
                //plus one when moving east or west
                len++;
            }
            for (int k = 0; k < len; k++) {
                r0 += directions[d];
                c0 += directions[d + 1];
                if (r0 >= 0 && r0 < R && c0 >= 0 && c0 < C) {
                    result[i++] = new int[]{r0, c0};
                }
            }
            d = (d + 1) % 4;
        }
        return result;
    }
}