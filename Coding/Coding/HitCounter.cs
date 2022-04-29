// https://leetcode.com/problems/design-hit-counter // not exact

using System.Collections.Generic;

public class HitCounter
{
    public Dictionary<long, Dictionary<char, int>> CounterData { get; set; }// using dictionary so that we can get count from past timestamp

    public Dictionary<char, Queue<long>> CounterDataQ { get; set; } 
    // using Queue, we can only get past 5 min data once. 
    //if multithreads get count at the same time, then only one thread will get count and next thread will give 0 because we are doing dequeue.

    public long TimeRangeInSec { get; set; }

    public HitCounter(long timeRangeInSec)
    {
        CounterData = new Dictionary<long, Dictionary<char, int>>();
        CounterDataQ = new Dictionary<char, Queue<long>>();
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

    public void CountQ(char key, long timeStamp)
    {
        if(CounterDataQ.ContainsKey(key))
        {
            CounterDataQ[key].Enqueue(timeStamp);
        }
        else
        {
            var data = new Queue<long>();
            data.Enqueue(timeStamp);

            CounterDataQ.Add(key, data);
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

    public int GetCountQ(char key, long timeStamp)
    {
        int result = 0;
        long endtime = timeStamp - TimeRangeInSec;

        if(CounterDataQ.ContainsKey(key))
        {
            while (CounterDataQ[key] != null && CounterDataQ[key].Count > 0 && CounterDataQ[key].Peek() < endtime)
            {
                CounterDataQ[key].Dequeue();
            }

            result = CounterDataQ[key].Count;
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

    public int GetTotalCountQ(long timeStamp)
    {
        int result = 0;
        long endtime = timeStamp - TimeRangeInSec;

        foreach (var item in CounterDataQ)
        {
            while (item.Value.Count > 0 && item.Value.Peek() < endtime)
            {
                item.Value.Dequeue();
            }

            result += item.Value.Count;
        }

        return result;
    }
}