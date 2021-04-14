namespace MusicShopManager.Interfaces
{    
    public interface IInstrument : IArticle
    {
       string Color { get; }

       bool IsElectronic { get; }
    }
}