using System.Collections.Generic;

public class QueueItem<T>
{
    public int Id { get; set; }
    public T Value { get; set; }

    public QueueItem(int id, T val)
    {
        Id = id;
        Value = val;
    }
}

public class LinkedHashMap<T>
{
    private LinkedList<QueueItem<T>> LL;

    private QueueItem<T> Front;

    private QueueItem<T> Rear;

    private Dictionary<int, LinkedListNode<QueueItem<T>>> Storage;

    public LinkedHashMap()
    {
        Storage = new Dictionary<int, LinkedListNode<QueueItem<T>>>();
        this.LL = new LinkedList<QueueItem<T>>();
        Front = null;
        Rear = null;
    }

    public void Enqueue(QueueItem<T> q)
    {
        if(Storage.ContainsKey(q.Id)){
            System.Console.WriteLine($"Key {q.Id} already exists.");
            return;
        }

        if (Storage.Count == 0 || !Storage.ContainsKey(q.Id))
        {
            LL.AddLast(q);
            Storage.Add(q.Id, LL.Last);
        }

        Front = LL.First.Value;
        Rear = LL.Last.Value;
    }

    public void ForceEnqueue(QueueItem<T> q)
    {
        if (Storage.Count != 0 && Storage.ContainsKey(q.Id))
        {
            LL.Remove(Storage[q.Id]); // This can be optimized using pointer replace. O(1).
            Storage.Remove(q.Id);
        }

        LL.AddLast(q);
        Storage.Add(q.Id, LL.Last);

        Front = LL.First.Value;
        Rear = LL.Last.Value;
    }

    public QueueItem<T> Dequeue()
    {
        if (Storage.Count == 0)
        {
            return null;
        }

        var tempFront = LL.First.Value;

        LL.RemoveFirst();
        Storage.Remove(tempFront.Id);

        Front = LL.First?.Value;
        Rear = LL.Last?.Value;

        return tempFront;
    }

    public QueueItem<T> Peek()
    {
        return Front;
    }
}