public class ReverseInt{
    public static int Run(int x){
        int res = 0;
        
        while(x != 0){
            int d = x / 10;
            int m = x % 10;
            
            if(res > int.MaxValue/10 || (res == int.MaxValue/10 && m > 7)){
                return 0;
            }
            
            if(res < int.MinValue/10 || (res == int.MinValue/10 && m < -8)){
                return 0;
            }
            res = res * 10 + m;
            
            x = d;
        }
        
        return res;
    }
}