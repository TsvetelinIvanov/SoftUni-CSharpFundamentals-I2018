public class MyList : AddRemoveCollection, IUseable
{
    public MyList() : base()
    {

    }

    public int Used => base.MyCollection.Count;

    public override string Remove()
    {
        string removedItem = base.MyCollection[0];
        base.MyCollection.RemoveAt(0);
        base.RemovedItems.Add(removedItem);

        return removedItem;
    }
}