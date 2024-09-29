public class Player
{
    internal int HappinessPointsSize { get; set; }    

    internal void Eat(string[] inputFoods)
    {
        foreach (string inputFood in inputFoods)
        {
            Food food = FoodFactory.GetFood(inputFood);
            this.HappinessPointsSize += food.PointsOfHappinessCount;
        }
    }

    public Mood GetMoodCondition()
    {
        return MoodFactory.GetMood(this.HappinessPointsSize);
    }    
}
