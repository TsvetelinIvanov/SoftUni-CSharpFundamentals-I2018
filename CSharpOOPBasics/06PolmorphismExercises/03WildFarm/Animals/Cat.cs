using System;
using System.Linq;

public class Cat : Feline
{
    private const double WeightFoodMultiplier = 0.30;

    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {

    }

    public override Type[] EatenFoods => new Type[] { typeof(Vegetable), typeof(Meat) };

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
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
