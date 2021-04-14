public interface INinja : IGameObject
{
    event OnMeloLemonMelonEatenHandler MeloLemonMelonEaten;

    string Name { get; }

    int Power { get; }

    int Stamina { get; }

    void Move(IMatrixPosition newPosition);

    void CollectVegetable(IVegetable vegetable);

    void EatVegetables();
}