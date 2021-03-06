using System;
using System.Collections.Generic;
using System.Linq;

public class Twilio
{
    // sort items by:
    // 1. number of occurrence of certain values
    // 2. value
    public static List<int> ItemSort(List<int> items){
        var countMap = new Dictionary<int, int>();
        foreach (var item in items)
        {
            if(countMap.ContainsKey(item)){
                countMap[item]++;
            }
            else{
                countMap.Add(item, 1);
            }
        }

        var freqMap = new Dictionary<int, List<int>>();
        foreach (var item in countMap)
        {
            if(freqMap.ContainsKey(item.Value)){
                freqMap[item.Value].Add(item.Key);
            }
            else{
                freqMap.Add(item.Value, new List<int>{item.Key});
            }
        }

        var orderedFreqMap = freqMap.OrderBy(x => x.Key);

        var result = new List<int>();
        foreach (var item in orderedFreqMap)
        {
            var sortedValue = item.Value;
            sortedValue.Sort();
            foreach (var val in sortedValue)
            {
                for (int i = 1; i <= item.Key; i++)
                {
                    result.Add(val);
                }
            }            
        }

        return result;
    }

    // public int[] frequencySort(int[] nums) {
    //     Map<Integer, Integer> freqCount = new HashMap();
    //     for (int n : nums) {
    //         freqCount.put(n, freqCount.getOrDefault(n, 0) + 1);
    //     }
    //     Comparator<Map.Entry<Integer, Integer>> valueComparator = new Comparator<Map.Entry<Integer, Integer>>() {
    //         @Override
    //         public int compare(Map.Entry<Integer, Integer> e1, Map.Entry<Integer, Integer> e2) {
    //             return e1.getValue() == e2.getValue() ? (e1.getKey() < e2.getKey() ? 1 : -1) : (e1.getValue() < e2.getValue() ? -1 : 1);
    //         }
    //     };
        
    //     List<Map.Entry<Integer, Integer>> sortedList = new ArrayList<Map.Entry<Integer, Integer>>(freqCount.entrySet());
    //     Collections.sort(sortedList, valueComparator);
    //     int[] result = new int[nums.length];
    //     int i = 0;
    //     for (Map.Entry<Integer, Integer> e : sortedList) {
    //         for (int j = 0; j < e.getValue(); ++j) {
    //             result[i++] = e.getKey();
    //         }
    //     }
    //     return result;
    // }

    // Find the max area when horizontal and vertical bars are removed. 
    public static long PrisonBreak(int n, int m, HashSet<int> h, HashSet<int> v){
        var x = new bool[n+1];
        var y = new bool[m+1];

        for (int i = 0; i < x.Length; i++)
        {
            x[i] = true;
        }

        for (int i = 0; i < y.Length; i++)
        {
            y[i] = true;
        }

        foreach (var item in h)
        {
            x[item] = false;
        }

        foreach (var item in v)
        {
            y[item] = false;
        }

        int cx = 0;
        int cy = 0;
        int maxX = 0;
        int maxY = 0;

        for (int i = 0; i < x.Length; i++)
        {
            if(x[i]){
                cx = 0;
            }
            else{
                cx++;
                maxX = Math.Max(maxX, cx);
            }
        }

        for (int i = 0; i < y.Length; i++)
        {
            if(y[i]){
                cy = 0;
            }
            else{
                cy++;
                maxY = Math.Max(maxY, cy);
            }
        }

        return (long)(maxX+1) * (maxY+1);
    }
}