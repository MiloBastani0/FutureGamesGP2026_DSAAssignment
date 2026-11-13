using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GenericStack<T>
{
    List<T> stack = new List<T>();
    public void Push(T element)
    {
        stack.Add(element);
    }

    public T Peek()
    {
        if(stack.Count != 0)
        {
        int i = stack.Count - 1;
            return stack[i];
        }
        throw new System.Exception();
    }
    
    public T Pop()
    {
        if(stack.Count != 0)
        {
        int i = stack.Count - 1;
        T value = stack[i];
        stack.RemoveAt(i);
        return value;
        }
        throw new System.Exception();
    }

    public void Clear()
    {
        stack.Clear();
    }

}
