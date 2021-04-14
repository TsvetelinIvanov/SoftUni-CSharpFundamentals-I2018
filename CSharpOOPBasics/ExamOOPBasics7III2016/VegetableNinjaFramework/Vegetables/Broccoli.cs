public class Broccoli : Vegetable
{
    private const char BroccoliCharValue = 'B';
    private const int PowerIncreaserSize = 10;
    private const int StaminaIncreaserSize = 0;
    private const int RegrowTimeSize = 3;

    public Broccoli(IMatrixPosition position) : base(position, BroccoliCharValue, PowerIncreaserSize, StaminaIncreaserSize, RegrowTimeSize)
    {

    }
}