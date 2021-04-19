public class Program
{
    static void Main(string[] args)
    {
        IRepository repository = new WeaponRepository();
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        IWeaponFactory weaponFactory = new WeaponFactory();
        IGemFactory gemFactory = new GemFactory();

        IRunnable engine = new Engine(gemFactory, weaponFactory, commandInterpreter, repository);
        engine.Run();
    }
}