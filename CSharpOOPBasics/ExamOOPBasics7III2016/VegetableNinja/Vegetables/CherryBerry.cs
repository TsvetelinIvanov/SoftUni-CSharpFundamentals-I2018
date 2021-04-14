public class CherryBerry : Vegetable
{
    private const char CherryBerryValue = 'C';
    private const int PowerIncreaserSize = 0;
    private const int StaminaIncreaserSize = 10;
    private const int RegrowTimeSize = 5;

    public CherryBerry(IMatrixPosition position) : base(position, CherryBerryValue, PowerIncreaserSize, StaminaIncreaserSize, RegrowTimeSize)
    {

    }
}