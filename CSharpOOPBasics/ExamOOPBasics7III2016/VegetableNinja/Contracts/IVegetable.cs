public interface IVegetable : IGameObject
{
    int PowerBonus { get; }

    int StaminaBonus { get; }

    int TimeToGrow { get; }
}