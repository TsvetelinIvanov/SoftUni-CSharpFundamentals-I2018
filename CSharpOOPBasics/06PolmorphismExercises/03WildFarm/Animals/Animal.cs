using System;
using System.Linq;

public abstract class Animal
{
    private const double WeightFoodMultiplier = 1;

    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public int FoodEaten
    {
        get { return this.foodEaten; }
        set { this.foodEaten = value; }
    }

    public virtual Type[] EatenFoods => new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};

    public virtual void MakeSound()
    {
        Console.WriteLine("AnimalSound");
    }

    public virtual void TryEatFood(Food food)
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
