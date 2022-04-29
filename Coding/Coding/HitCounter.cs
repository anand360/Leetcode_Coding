// https://leetcode.com/problems/design-hit-counter // not exact

using System.Collections.Generic;

public class HitCounter
{
    public Dictionary<long, Dictionary<char, int>> CounterData { get; set; }
    public long TimeRangeInSec { get; set; }

    public HitCounter(long timeRangeInSec)
    {
        CounterData = new Dictionary<long, Dictionary<char, int>>();
        TimeRangeInSec = timeRangeInSec;
    }

    public void Count(char key, long timeStamp)
    {
        if(CounterData.ContainsKey(timeStamp))
        {
            if(CounterData[timeStamp].ContainsKey(key))
            {
                CounterData[timeStamp][key]++;
            }
            else
            {
                CounterData[timeStamp].Add(key, 1);
            }
        }
        else{            
            var data = new Dictionary<char, int>()
            {
                {key, 1}
            };

            CounterData.Add(timeStamp, data);
        }
    }

    public int GetCount(char key, long timeStamp)
    {
        int result = 0;
        long endtime = timeStamp - TimeRangeInSec;

        while(timeStamp >= endtime)
        {
            if(CounterData.ContainsKey(timeStamp) && CounterData[timeStamp].ContainsKey(key))
            {
                result += CounterData[timeStamp][key];
            }

            timeStamp--;
        }

        return result;
    }

    public int GetTotalCount(long timeStamp)
    {
        int result = 0;
        long endtime = timeStamp - TimeRangeInSec;

        while(timeStamp >= endtime)
        {
            if(CounterData.ContainsKey(timeStamp))
            {
                foreach(var item in CounterData[timeStamp])
                {
                    result += item.Value;
                }
            }

            timeStamp--;
        }

        return result;
    }
}