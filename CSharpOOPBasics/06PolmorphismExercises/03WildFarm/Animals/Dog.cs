using System;
using System.Linq;

public class Dog : Mammal
{
    private const double WeightFoodMultiplier = 0.40;

    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {

    }

    public override Type[] EatenFoods => new Type[] { typeof(Meat) };

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
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
