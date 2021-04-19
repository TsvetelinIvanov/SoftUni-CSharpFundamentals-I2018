public class AddCommand : Command
{
    private IGemFactory gemFactory;
    private IRepository repository;

    public AddCommand(string[] data) : base(data)
    {

    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        int index = int.Parse(this.Data[1]);
        string[] gemData = this.Data[2].Split();
        string clarity = gemData[0];
        string type = gemData[1];

        IGem gem = this.gemFactory.CreateGem(clarity, type);
        this.repository.AddGem(weaponName, index, gem);
    }
}