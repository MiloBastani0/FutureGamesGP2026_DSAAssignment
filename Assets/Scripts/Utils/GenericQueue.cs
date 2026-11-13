using System.Collections.Generic;

public class GenericQueue<T>
{
    List<T> queue = new List<T>();
    public void Push(T element)
    {
        queue.Add(element);
    }

    public T Peek()
    {
        if (queue.Count != 0)
        {
            int i = 0;
            return queue[i];
        }
        throw new System.Exception();
    }

    public T Pop()
    {
        if (queue.Count != 0)
        {
            int i = 0;
            T value = queue[i];
            queue.RemoveAt(i);
            return value;
        }
        throw new System.Exception();
    }

    public void Clear()
    {
        queue.Clear();
    }

}
