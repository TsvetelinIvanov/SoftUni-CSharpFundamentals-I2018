using System.Collections.Generic;

namespace MyTunesShop
{
    public interface IRateable
    {
        IList<int> Ratings { get; }

        void PlaceRating(int rating);
    }
}