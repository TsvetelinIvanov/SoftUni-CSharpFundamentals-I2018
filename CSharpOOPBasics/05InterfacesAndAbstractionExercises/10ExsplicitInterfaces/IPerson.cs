public interface IPerson : IHuman
{
    int Age { get; set; }

    string GetName();
}