using System.Linq;
using System.Reflection;

public class Engine : IRunnable
{
    private IGemFactory gemFactory;
    private IWeaponFactory weaponFactory;
    private ICommandInterpreter commandInterpreter;
    private IRepository repository;
    private IReader reader;
    private IWriter writer;

    public Engine(IGemFactory gemFactory, IWeaponFactory weaponFactory, ICommandInterpreter commandInterpreter, IRepository repository, IReader reader, IWriter writer)
    {
        this.gemFactory = gemFactory;
        this.weaponFactory = weaponFactory;
        this.commandInterpreter = commandInterpreter;
        this.repository = repository;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            string[] inputData = this.reader.ReadLine().Split(';');
            IExecutable executable = this.commandInterpreter.InterpretCommand(inputData[0], inputData.Skip(1).ToArray());
            FieldInfo[] fields = executable.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            if (fields.Any(f => f.FieldType == typeof(IRepository)))
            {
                fields.Single(f => f.FieldType == typeof(IRepository)).SetValue(executable, this.repository);
            }

            if (fields.Any(f => f.FieldType == typeof(IWeaponFactory)))
            {
                fields.Single(f => f.FieldType == typeof(IWeaponFactory)).SetValue(executable, this.weaponFactory);
            }

            if (fields.Any(f => f.FieldType == typeof(IGemFactory)))
            {
                fields.Single(f => f.FieldType == typeof(IGemFactory)).SetValue(executable, this.gemFactory);
            }

            if (fields.Any(f => f.FieldType == typeof(IWriter)))
            {
                fields.Single(f => f.FieldType == typeof(IWriter)).SetValue(executable, this.writer);
            }

            executable.Execute();
        }
    }
}