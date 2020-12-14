using System;
using System.Collections.Generic;


public class LRUCache
{
    public int Size { get; set; }

    private Dictionary<int, LinkedListNode<Tuple<int,int>>> stor { get; set; }

    private LinkedList<Tuple<int,int>> data { get; set; }

    public LRUCache(int capacity)
    {
        this.Size = capacity;
        data = new LinkedList<Tuple<int,int>>();
        stor = new Dictionary<int, LinkedListNode<Tuple<int,int>>>();
    }

    public int Get(int key)
    {
        if (!stor.ContainsKey(key))
        {
            return -1;
        }

        var node = stor[key];
        data.Remove(node);

        data.AddFirst(node);

        return node.Value.Item2;
    }

    public void Put(int key, int val)
    {
        if (stor.ContainsKey(key))
        {
            stor[key].Value = new Tuple<int, int>(key, val);
            var moveNode = stor[key];
            data.Remove(moveNode);
            data.AddFirst(moveNode);
            return;
        }

        if (stor.Count == Size)
        {
            var removeKey = data.Last.Value.Item1;
            data.RemoveLast();
            stor.Remove(removeKey);
        }

        var node = new LinkedListNode<Tuple<int,int>>(new Tuple<int, int>(key, val));
        data.AddFirst(node);

        stor.Add(key, data.First);
    }
}