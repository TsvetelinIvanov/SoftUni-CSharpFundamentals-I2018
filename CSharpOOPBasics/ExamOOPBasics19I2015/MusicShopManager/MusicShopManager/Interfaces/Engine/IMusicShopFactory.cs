namespace MusicShopManager.Interfaces.Engine
{
    public interface IMusicShopFactory
    {
        IMusicShop CreateMusicShop(string name);
    }
}