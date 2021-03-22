using System;
using System.Collections.Generic;

public class AddRemoveCollection : AddCollection, IRemovable
{
    private List<string> removedItems;

    public AddRemoveCollection() : base()
    {
        this.RemovedItems = new List<string>();
    }

    public List<string> RemovedItems
    {
        get { return this.removedItems; }
        set { this.removedItems = value; }
    }

    public override int Add(string item)
    {
        base.MyCollection.Insert(0, item);
        base.AddedIndexes.Add(0);

        return 0;
    }

    public virtual string Remove()
    {
        string removedItem = base.MyCollection[base.MyCollection.Count - 1];
        base.MyCollection.RemoveAt(base.MyCollection.Count - 1);
        this.RemovedItems.Add(removedItem);

        return removedItem;
    }

    public void PrintRemovedItems()
    {
        Console.WriteLine(string.Join(" ", this.RemovedItems));
    }
}