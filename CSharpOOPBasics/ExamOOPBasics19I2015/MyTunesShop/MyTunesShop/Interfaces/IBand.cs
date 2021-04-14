using System.Collections.Generic;

namespace MyTunesShop
{
    public interface IBand : IPerformer
    {
        IList<string> Members { get; }

        void AddMember(string memberName);
    }
}