class Frog : Animal
{
    private const string ProducedSound = "Ribbit";

    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override string ProduceSound()
    {
        return $"{ProducedSound}";
    }
}