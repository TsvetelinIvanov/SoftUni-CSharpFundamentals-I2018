namespace MusicShopManager.Interfaces
{    
    public interface IMicrophone : IArticle
    {
        bool HasCable { get; }
    }
}