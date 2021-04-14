namespace MusicShopManager.Interfaces
{
    public interface IDrums : IInstrument
    {
        int Width { get; }

        int Height { get; }
    }
}