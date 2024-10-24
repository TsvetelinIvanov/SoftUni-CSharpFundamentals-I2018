using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private List<T> elements;
    private int currentIndex;

    public ListyIterator(T[] elements)
    {
        this.Elements = new List<T>(elements);
        this.currentIndex = 0;
    }

    public List<T> Elements
    {
        get { return this.elements; }
        private set { this.elements = value; }
    }


    public bool Move()
    {
        this.currentIndex++;
        if (this.currentIndex < this.Elements.Count)
        {
            return true;
        }
        else
        {
            currentIndex--;
            
            return false;
        }
    }

    public bool HasNext()
    {
        if (this.currentIndex + 1 < this.Elements.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Print()
    {
        if (this.Elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid operation!");
        }

        Console.WriteLine(this.Elements[currentIndex]);
    }
}
