using System;
using System.Collections.Generic;
using System.Linq;

public class Merge3SortArray
{
    public static int[] run(int[] a, int[] b, int[] c){
        var res = new HashSet<int>();
        for(int ai = 0, bi = 0, ci = 0; ai < a.Length || bi < b.Length || ci < c.Length;){
            int m = Math.Min(ai < a.Length ? a[ai] : int.MaxValue, Math.Min(bi < b.Length ? b[bi] : int.MaxValue , ci < c.Length ? c[ci] : int.MaxValue));

            res.Add(m);

            if(ai < a.Length && a[ai] == m) ++ai;
            if(bi < b.Length && b[bi] == m) ++bi;
            if(ci < c.Length && c[ci] == m) ++ci;
        }

        return res.ToArray();
    }
}