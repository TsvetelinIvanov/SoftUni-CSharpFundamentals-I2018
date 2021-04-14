public interface IBlankSpace : IGameObject
{
    int GrowthTime { get; }

    VegetableType VegetableHolder { get; }

    void Grow();
}