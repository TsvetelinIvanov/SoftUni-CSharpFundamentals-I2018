using System;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    private List<T> items;

    public Box()
    {
        this.Items = new List<T>();
    }

    public List<T> Items
    {
        get { return this.items; }
        private set { this.items = value; }
    }

    public void Add(T item)
    {
        this.Items.Add(item);
    }

    //public void Swap(int[] indexesForSwapping)
    //{
    //    int swappedIndex = indexesForSwapping[0];
    //    int swappingIndex = indexesForSwapping[1];

    //    T swappedElement = this.Items[swappedIndex];
    //    this.Items[swappedIndex] = this.Items[swappingIndex];
    //    this.Items[swappingIndex] = swappedElement;
    //}

    public int GiveCountOfGreathers(T itemForComparing)
    {
        int greaterItemsCount = 0;
        foreach (T item in this.items)
        {
            if (item.CompareTo(itemForComparing) > 0)
            {
                greaterItemsCount++;
            }
        }

        return greaterItemsCount;
    }

    //public override string ToString()
    //{
    //    StringBuilder resultBuilder = new StringBuilder();
    //    foreach (T item in this.Items)
    //    {
    //        resultBuilder.AppendLine($"{item.GetType().FullName}: {item}");
    //    }
    
    //    return resultBuilder.ToString().TrimEnd();
    //}
}
