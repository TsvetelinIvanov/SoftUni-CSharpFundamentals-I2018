using MusicShopManager.Models;

namespace MusicShopManager.Interfaces
{
    public interface IAcousticGuitar : IGuitar
    {
        bool CaseIncluded { get; }

        StringMaterial StringMaterial { get; }
    }
}