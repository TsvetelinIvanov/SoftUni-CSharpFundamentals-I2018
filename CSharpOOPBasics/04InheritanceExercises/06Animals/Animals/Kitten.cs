public class Kitten : Cat
{
    private const string ProducedSound = "Meow";

    public Kitten(string name, int age)
        : base(name, age, "Female")
    {

    }

    public override string ProduceSound()
    {
        return $"{ProducedSound}";
    }
}