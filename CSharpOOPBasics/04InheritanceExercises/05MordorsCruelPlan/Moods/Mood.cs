public abstract class Mood
{
    private int happinessPointsSize;

    public Mood(int happinessPointsSize)
    {
        this.HappinessPointsSize = happinessPointsSize;
    }

    private int HappinessPointsSize
    {
        get { return this.happinessPointsSize; }
        set { this.happinessPointsSize = value; }
    }
}