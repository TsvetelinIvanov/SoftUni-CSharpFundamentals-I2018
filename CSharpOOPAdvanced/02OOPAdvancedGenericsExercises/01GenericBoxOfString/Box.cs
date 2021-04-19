public class Box<T>
{
    private T item;

    public Box(T item)
    {
        this.Item = item;
    }

    public T Item
    {
        get { return this.item; }
        private set { this.item = value; }
    }

    public override string ToString()
    {
        return $"{this.Item.GetType().FullName}: {this.Item}";
    }
}