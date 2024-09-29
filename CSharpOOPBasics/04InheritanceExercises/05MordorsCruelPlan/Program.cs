using System;

public class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        string[] inputFoods = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);        
        player.Eat(inputFoods);
        
        Mood mood = player.GetMoodCondition();
        Console.WriteLine(player.HappinessPointsSize);
        Console.WriteLine(mood);
    }
}
