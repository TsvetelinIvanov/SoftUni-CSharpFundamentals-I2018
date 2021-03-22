using System;

public class Program
{
    static void Main(string[] args)
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();
        string[] itemsToAdd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        AddItemsToColections(addCollection, addRemoveCollection, myList, itemsToAdd);
        int removedItemsCount = int.Parse(Console.ReadLine());
        RemoveItemsFromCollections(addRemoveCollection, myList, removedItemsCount);
        addCollection.PrintIndexes();
        addRemoveCollection.PrintIndexes();
        myList.PrintIndexes();
        addRemoveCollection.PrintRemovedItems();
        myList.PrintRemovedItems();
    }

    private static void AddItemsToColections(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList, string[] itemsToAdd)
    {
        foreach (string item in itemsToAdd)
        {
            addCollection.Add(item);
            addRemoveCollection.Add(item);
            myList.Add(item);
        }
    }

    private static void RemoveItemsFromCollections(AddRemoveCollection addRemoveCollection, MyList myList, int removedItemsCount)
    {
        for (int i = 0; i < removedItemsCount; i++)
        {
            addRemoveCollection.Remove();
            myList.Remove();
        }
    }    
}