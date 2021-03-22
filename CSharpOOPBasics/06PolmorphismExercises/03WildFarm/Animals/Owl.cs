using System;
using System.Linq;

public class Owl : Bird
{
    private const double WeightFoodMultiplier = 0.25;

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {

    }

    public override Type[] EatenFoods => new Type[] { typeof(Meat)};

    public override void MakeSound()
    {
        Console.WriteLine("Hoot Hoot");
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