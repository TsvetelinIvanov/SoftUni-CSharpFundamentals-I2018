using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public T Remove()
    {
        T removedItem = this.data.Last();
        this.data.RemoveAt(this.data.Count - 1);

        return removedItem;
    }
}