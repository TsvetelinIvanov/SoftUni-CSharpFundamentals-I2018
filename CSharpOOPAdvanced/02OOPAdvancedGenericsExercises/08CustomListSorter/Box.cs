using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public T Remove(int index)
    {
        T removedIndex = this.Items[index];
        this.Items.RemoveAt(index);
        return removedIndex;
    }

    public bool Contains(T item)
    {
        return this.Items.Contains(item);
    }

    public void Swap(int swappedIndex, int swappingIndex)
    {
        T swappedElement = this.Items[swappedIndex];
        this.Items[swappedIndex] = this.Items[swappingIndex];
        this.Items[swappingIndex] = swappedElement;
    }

    public int CountGreaterThan(T itemForComparing)
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

    public T Min()
    {
        //T minItem = this.Items.FirstOrDefault();
        //foreach (T item in this.Items)
        //{
        //    if (item.CompareTo(minItem) < 0)
        //    {
        //        minItem = item;
        //    }
        //}

        T minItem = this.Items.Min();
        
        return minItem;
    }

    public T Max()
    {
        //T maxItem = this.Items.FirstOrDefault();
        //foreach (T item in this.Items)
        //{
        //    if (item.CompareTo(maxItem) > 0)
        //    {
        //        maxItem = item;
        //    }
        //}

        T maxItem = this.Items.Max();
        
        return maxItem;
    }

    public void Sort()
    {
        this.Items = this.Items.OrderBy(i => i).ToList();
    }

    public override string ToString()
    {
        StringBuilder resultBuilder = new StringBuilder();
        foreach (T item in this.Items)
        {
            resultBuilder.AppendLine($"{item}");
        }
        
        return resultBuilder.ToString().TrimEnd();
    }
}
