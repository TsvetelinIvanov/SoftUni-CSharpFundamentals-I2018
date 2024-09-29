public class GoldenEditionBook : Book
{
    private const decimal PriceMultiplier = 1.3m; // + 30%

    public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
    {

    }

    public override decimal Price
    {
        get => base.Price;
        set => base.Price = value * PriceMultiplier;
    }
}
