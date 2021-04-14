namespace MusicShopManager.Interfaces
{
    public interface IArticle
    {
        string Make { get; }

        string Model { get; }

        decimal Price { get; }        
    }
}