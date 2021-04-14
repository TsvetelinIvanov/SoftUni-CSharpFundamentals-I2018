using MusicShopManager.Interfaces;
using MusicShopManager.Interfaces.Engine;
using MusicShopManager.Models;

namespace MusicShopManager.Engine.Factories
{
    public class MusicShopFactory : IMusicShopFactory
    {
        public IMusicShop CreateMusicShop(string name)
        {
            return new MusicShop(name);
        }
    }
}