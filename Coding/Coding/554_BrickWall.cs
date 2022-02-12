// https://leetcode.com/problems/brick-wall/

using System;
using System.Collections.Generic;

public class BrickWall{
    public static int Run(IList<IList<int>> wall){
        if(wall == null || wall.Count == 0){
            return 0;
        }

        var map = new Dictionary<int, int>();
        foreach (var item in wall)
        {
            var preSum = 0;
            for (int i = 0; i < item.Count - 1; i++)
            {
                preSum += item[i];
                if(map.ContainsKey(preSum)){
                    map[preSum]++;
                }else{
                    map.Add(preSum, 1);
                }
            }
        }

        var result = wall.Count;
        foreach (var item in map)
        {
            result = Math.Min(result, wall.Count - item.Value);
        }

        return result;
    }
}