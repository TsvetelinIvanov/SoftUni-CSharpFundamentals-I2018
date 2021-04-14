public class Asparagus : Vegetable
{
    private const char AsparagusCharValue = 'A';
    private const int PowerIncreaserSize = 5;
    private const int StaminaIncreaserSize = -5;
    private const int RegrowTimeSize = 2;

    public Asparagus(IMatrixPosition position) : base(position, AsparagusCharValue, PowerIncreaserSize, StaminaIncreaserSize, RegrowTimeSize)
    {

    }
}