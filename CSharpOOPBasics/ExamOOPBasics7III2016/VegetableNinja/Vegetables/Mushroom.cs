public class Mushroom : Vegetable
{
    private const char MushroomCharValue = 'M';
    private const int PowerIncreaserSize = -10;
    private const int StaminaIncreaserSize = -10;
    private const int RegrowTimeSize = 5;

    public Mushroom(IMatrixPosition position) : base(position, MushroomCharValue, PowerIncreaserSize, StaminaIncreaserSize, RegrowTimeSize)
    {

    }
}