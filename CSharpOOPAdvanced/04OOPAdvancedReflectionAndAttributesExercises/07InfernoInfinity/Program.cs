public class Program
{
    static void Main(string[] args)
    {
        IGemFactory gemFactory = new GemFactory();
        IWeaponFactory weaponFactory = new WeaponFactory();
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        IRepository repository = new WeaponRepository();

        IRunnable engine = new Engine(gemFactory, weaponFactory, commandInterpreter, repository);
        engine.Run();
    }
}
