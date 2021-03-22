using System;
using System.Collections.Generic;

public class AddCollection : IAddable
{
    private List<string> myCollection;
    private List<int> addedIndexes;

    public AddCollection()
    {
        this.MyCollection = new List<string>();
        this.AddedIndexes = new List<int>();
    }

    public List<string> MyCollection
    {
        get { return this.myCollection; }
        set { this.myCollection = value; }
    }

    public List<int> AddedIndexes
    {
        get { return this.addedIndexes; }
        set { this.addedIndexes = value; }
    }

    public virtual int Add(string item)
    {
        this.MyCollection.Add(item);
        int index = this.MyCollection.Count - 1;
        this.AddedIndexes.Add(index);

        return index;
    }

    public void PrintIndexes()
    {
        Console.WriteLine(string.Join(" ", this.AddedIndexes)); 
    }
}