public class Tomcat : Cat
{
    private const string ProducedSound = "MEOW";

    public Tomcat(string name, int age) : base(name, age, "Male")
    {

    }

    public override string ProduceSound()
    {
        return $"{ProducedSound}";
    }
}
