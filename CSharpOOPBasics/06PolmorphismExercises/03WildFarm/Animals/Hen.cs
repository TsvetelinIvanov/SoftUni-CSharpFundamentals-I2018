using System;
using System.Linq;

public class Hen : Bird
{
    private const double WeightFoodMultiplier = 0.35;

    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine("Cluck");
    }

    public override void TryEatFood(Food food)
    {
        Type foodType = food.GetType();
        if (this.EatenFoods.Contains(foodType))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightFoodMultiplier;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}