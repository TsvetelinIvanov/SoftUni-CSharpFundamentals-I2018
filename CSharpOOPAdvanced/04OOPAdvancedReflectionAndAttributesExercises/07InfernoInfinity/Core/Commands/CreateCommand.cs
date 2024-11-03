public class CreateCommand : Command
{
    private IWeaponFactory weaponFactory;
    private IRepository repository;

    public CreateCommand(string[] data) : base(data)
    {

    }

    public override void Execute()
    {
        string[] weaponData = this.Data[0].Split();
        string rarity = weaponData[0];
        string type = weaponData[1];
        
        string name = this.Data[1];
        IWeapon weapon = this.weaponFactory.CreateWeapon(rarity, type, name);
        
        this.repository.AddWeapon(weapon);
    }
}
