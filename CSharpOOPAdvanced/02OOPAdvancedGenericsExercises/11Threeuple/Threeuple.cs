public class Threeuple<T1, T2, T3>
{
    private T1 firstItem;
    private T2 secondItem;
    private T3 thirdItem;

    public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
    {
        this.FiirstItem = firstItem;
        this.SecondItem = secondItem;
        this.ThirdItem = thirdItem;
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

    public T3 ThirdItem
    {
        get { return this.thirdItem; }
        private set { this.thirdItem = value; }
    }

    public override string ToString()
    {
        return $"{this.FiirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
    }
}