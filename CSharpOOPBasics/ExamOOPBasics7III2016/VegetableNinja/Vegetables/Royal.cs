public class Royal : Vegetable
{
    private const char RoyalCharValue = 'R';
    private const int PowerIncreaserSize = 20;
    private const int StaminaIncreaserSize = 10;
    private const int RegrowTimeSize = 10;

    public Royal(IMatrixPosition position) : base(position, RoyalCharValue, PowerIncreaserSize, StaminaIncreaserSize, RegrowTimeSize)
    {

    }
}