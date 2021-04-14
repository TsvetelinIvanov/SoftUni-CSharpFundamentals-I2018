using System.Collections.Generic;

namespace MyTunesShop
{
    public interface IPerformer
    {
        string Name { get; }

        PerformerType Type { get; }

        IList<ISong> Songs { get; }
    }
}