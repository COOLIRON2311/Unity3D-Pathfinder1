using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PriorityQueue<T>
{
    private readonly SortedDictionary<float, LinkedList<T>> data = new();

    public int Count { get; private set; } = 0;

    public PriorityQueue() { }

    public void Enqueue(float priority, T value)
    {
        if (!data.ContainsKey(priority))
            data[priority] = new();
        data[priority].AddLast(value);
        Count += 1;
    }

    public (float priority, T value) Dequeue()
    {
        Count--;
        var (k, v) = data.First();
        if (v.Count == 1)
        {
            data.Remove(k);
            return (k, v.First.Value);
        }

        var value = v.Last.Value;
        v.RemoveLast();
        return (k, value);
    }
}
