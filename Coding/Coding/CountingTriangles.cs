using System.Collections.Generic;
using System.Linq;

public class Side
{
    public int a;
    public int b;
    public int c;
     public Side(int a, int b, int c)
     {
         this.a = a;
         this.b = b;
         this.c = c;
     }
}

public class CountingTriangles
{
    public static int Run(List<Side> arr){
        if(arr == null || !arr.Any()){
            return 0;
        }

        var dict = new Dictionary<int, int>();
        foreach (Side item in arr)
        {
            var sum = item.a + item.b + item.c;
            if (!dict.ContainsKey(sum))
            {
                dict.Add(sum, 1);
            }
        }

        return dict.Count;
    }
}