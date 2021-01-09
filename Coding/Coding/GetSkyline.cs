// https://leetcode.com/problems/the-skyline-problem/discuss/955736/JAVA-PriorityQueue-with-O(nlogn)-time-complexityoror-Not-using-remove-method
// https://leetcode.com/problems/the-skyline-problem/discuss/61197/(Guaranteed)-Really-Detailed-and-Good-(Perfect)-Explanation-of-The-Skyline-Problem


using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public class BuildingPoint : IComparable<BuildingPoint>
{
    public int x { get; set; }
    public bool IsStart { get; set; }
    public int height { get; set; }

    public BuildingPoint(int x, bool IsStart, int h)
    {
        this.x = x;
        this.IsStart = IsStart;
        this.height = h;
    }

    public int CompareTo([AllowNull] BuildingPoint other)
    {
        if (this.x != other.x)
        {
            return this.x - other.x;
        }
        else
        {
            if (this.IsStart && other.IsStart)
            {
                return other.height - this.height;
            }
            else if (this.IsStart && !other.IsStart)
            {
                return (-1 * this.height) - other.height;
            }
            else if (!this.IsStart && !other.IsStart)
            {
                return this.height - other.height;
            }
            else
            {
                return this.height + other.height;
            }
        }
    }
}

public class GetSkyline
{

    // NOT WOrking
    public static IList<IList<int>> Run(int[][] buildings)
    {
        if (buildings == null)
        {
            return null;
        }

        if (buildings.Length == 0)
        {
            return new List<IList<int>>();
        }

        var buildingPoints = new List<BuildingPoint>();
        foreach (var item in buildings)
        {
            buildingPoints.Add(new BuildingPoint(item[0], true, item[2]));
            buildingPoints.Add(new BuildingPoint(item[1], false, item[2]));
        }

        buildingPoints.Sort();

        var result = new List<IList<int>>();
        var map = new Dictionary<int, int>();
        int preMax = 0;
        foreach (var item in buildingPoints)
        {
            if (item.IsStart)
            {
                if (map.ContainsKey(item.height))
                {
                    map[item.height]++;
                }
                else
                {
                    map.Add(item.height, 1);
                }
            }
            else
            {
                if (map.ContainsKey(item.height) && map[item.height] > 1)
                {
                    map[item.height]--;
                }
                else
                {
                    map.Remove(item.height);
                }
            }

            int curMax = map.Keys.LastOrDefault();
            if(curMax != preMax){
                result.Add(new List<int>{item.x, curMax});
                preMax = curMax;
            }
        }

        return result;
    }

    public static IList<IList<int>> BruteforceRun(int[][] buildings)
    {
        if (buildings == null)
        {
            return null;
        }

        if (buildings.Length == 0)
        {
            return new List<IList<int>>();
        }

        var map = new Dictionary<int, int>();
        for (int i = 0; i < buildings.Length; i++)
        {
            var building = buildings[i];
            if (i > 0 && building[0] - buildings[i - 1][1] > 1)
            {
                int x = 0;
                while (buildings[i - 1][1] + x < building[0])
                {
                    map.Add(buildings[i - 1][1] + x, 0);
                    x++;
                }
            }

            for (int j = building[0]; j < building[1]; j++)
            {
                if (map.ContainsKey(j) && map[j] < building[2])
                {
                    map[j] = building[2];
                }
                else if (!map.ContainsKey(j))
                {
                    map.Add(j, building[2]);
                }
            }
        }

        var result = new List<IList<int>>();

        result.Add(new List<int> { buildings[0][0], map[buildings[0][0]] });
        var prevVal = map[buildings[0][0]];
        foreach (var item in map)
        {
            if (prevVal != item.Value)
            {
                result.Add(new List<int> { item.Key, item.Value });
                prevVal = item.Value;
            }
        }
        result.Add(new List<int> { buildings[buildings.Length - 1][1], 0 });

        return result;
    }
}