using System.Collections.Generic;

namespace MusicShopManager.Interfaces.Engine
{
    public interface IUserInterface
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}