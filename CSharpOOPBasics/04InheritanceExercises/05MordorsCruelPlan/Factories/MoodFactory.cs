public class MoodFactory
{
    private const int AngryTopBorder = -6;
    private const int SadTopBorder = 0;
    private const int HappyTopBorder = 15;

    public static Mood GetMood(int happinessPointsSize)
    {
        if (happinessPointsSize <= AngryTopBorder)
        {
            return new Angry(happinessPointsSize);
        }
        else if (happinessPointsSize <= SadTopBorder)
        {
            return new Sad(happinessPointsSize);
        }
        else if (happinessPointsSize <= HappyTopBorder)
        {
            return new Happy(happinessPointsSize);
        }
        else
        {
            return new JavaScript(happinessPointsSize);
        }
    }
}