using System.Collections.Generic;
using System;
public class GenericQueue<T>
{
    private List<T> queue;
    public int Count => queue.Count;
    public GenericQueue()
    {
        queue = new List<T>();
    }
    
    public void Enqueue(T item)
    {
        queue.Add(item);
    }
    
    public T Peek()
    {
        if(queue.Count == 0)
            throw new Exception("Queue is empty, cannot peek");
        
        return queue[0];
    }
    
    public T Dequeue()
    {
        if(queue.Count == 0)
            throw new Exception("Queue is empty, cannot dequeue");
        T firstItem = queue[0];
        queue.RemoveAt(0);
        return firstItem;
    }
}

