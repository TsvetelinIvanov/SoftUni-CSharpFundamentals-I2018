using System;

public class Tiger : Feline
{
    private const double WeightFoodMultiplier = 1;

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {

    }

    public override Type[] EatenFoods => new Type[] { typeof(Meat) };

    public override void MakeSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}
