﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private List<T> elements;

    public Stack()
    {
        this.elements = new List<T>();
    }

    public void Push(T[] comingElements)
    {
        this.elements.AddRange(comingElements);
    }

    public void Pop()
    {
        if (this.elements.Count == 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            this.elements.RemoveAt(this.elements.Count - 1);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.elements.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
