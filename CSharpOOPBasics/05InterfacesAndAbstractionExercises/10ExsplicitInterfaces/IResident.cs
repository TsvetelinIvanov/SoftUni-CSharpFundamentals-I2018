public interface IResident : IHuman
{
    string Country { get; set; }

    string GetName();
}