using System.Collections.Generic;

namespace MyTunesShop
{
    public interface IAlbum : IMedia
    {
        IPerformer Performer { get; }

        string Genre { get; }

        int Year { get; }

        IList<ISong> Songs { get; }

        void AddSong(ISong song);
    }
}