public abstract class Food
{
    private int pointsOfHappinessCount;

    public Food(int pointsOfHappinessCount)
    {
        this.PointsOfHappinessCount = pointsOfHappinessCount;
    }

    public int PointsOfHappinessCount
    {
        get { return this.pointsOfHappinessCount; }
        private set { this.pointsOfHappinessCount = value; }
    }
}