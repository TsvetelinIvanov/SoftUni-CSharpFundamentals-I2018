public class Program
{
    static void Main(string[] args)
    {
        IRepository repository = new WeaponRepository();
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        IWeaponFactory weaponFactory = new WeaponFactory();
        IGemFactory gemFactory = new GemFactory();
        IReader reader = new Reader();
        IWriter writer = new Writer();

        IRunnable engine = new Engine(gemFactory, weaponFactory, commandInterpreter, repository, reader, writer);
        engine.Run();
    }
}