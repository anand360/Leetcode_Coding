// https://codingcompetitions.withgoogle.com/kickstart/round/0000000000051060/0000000000058b89
//https://play.golang.org/p/88NBNRfenXz
// https://ideone.com/4proeS

public class Mural
{
    public static int Run(int[] a){
        if(a == null){
            return 0;
        }

        int tpoint = 0;
        
        for (int i = 0; i < (a.Length+1)/2; i++)
        {
            tpoint += a[i];
        }

        int temppoint = tpoint;
        for (int i = 0; i+(a.Length+1)/2 < a.Length; i++)
        {
            temppoint -= a[i];
            temppoint += a[i+(a.Length+1)/2];
            if(tpoint < temppoint){
                tpoint = temppoint;
            }
        }

        return tpoint;
    }
}