public class Tuple<T1, T2>
{
    private T1 firstItem;
    private T2 secondItem;

    public Tuple(T1 firstItem, T2 secondItem)
    {
        this.FiirstItem = firstItem;
        this.SecondItem = secondItem;
    }

    public T1 FiirstItem
    {
        get { return this.firstItem; }
        private set { this.firstItem = value; }
    }

    public T2 SecondItem
    {
        get { return this.secondItem; }
        private set { this.secondItem = value; }
    }

    public override string ToString()
    {
        return $"{this.FiirstItem} -> {this.SecondItem}";
    }
}