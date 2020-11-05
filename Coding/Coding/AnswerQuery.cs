//queries = [[2, 3], [1, 2], [2, 1], [2, 3], [2, 2]]
// output = [-1, 2, -1, 2]

using System.Collections.Generic;
using System.Linq;

public class AnswerQuery
{
    public static int[] Run(List<int[]> l){
        if(l == null || !l.Any()){
            return null;
        }

        var arr = new bool[]{ false, false, false, false, false};
        var res = new List<int>();
        foreach (var item in l)
        {
            if(item[0] == 1){
                arr[item[1] -1] = true;
            }
            else if(item[0] == 2){
                
                if(arr[item[1]-1]){
                    res.Add(item[1]);
                }else{
                    var iright = -1;
                    for (int i = item[1] - 1; i < arr.Length; i++)
                    {
                        if(arr[i]){
                            iright = i+1;
                            break;
                        }
                    }
                    res.Add(iright);
                }
            }
        }
        
        return res.ToArray();
    }
}