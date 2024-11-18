using Forum.App.Models;

namespace Forum.App.Contracts
{
    public interface IPositionable
    {
        Position Position { get; }
    }
}
