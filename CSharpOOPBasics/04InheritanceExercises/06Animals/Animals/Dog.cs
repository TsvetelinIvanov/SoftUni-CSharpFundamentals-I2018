public class Dog : Animal
{
    private const string ProducedSound = "Woof!";

    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override string ProduceSound()
    {
        return $"{ProducedSound}";
    }
}