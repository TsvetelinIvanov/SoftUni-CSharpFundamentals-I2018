using System.Collections.Generic;

namespace MusicShopManager.Interfaces.Engine
{
    public interface ICommand
    {
        string Name { get; }

        IDictionary<string, string> Parameters { get; }
    }
}