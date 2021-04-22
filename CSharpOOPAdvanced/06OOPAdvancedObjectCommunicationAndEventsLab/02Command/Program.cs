public class Program
{
    static void Main(string[] args)
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        Warrior warrior = new Warrior("Gosho", 10, combatLogger);
        Dragon dragon = new Dragon("Peter", 100, 25, combatLogger);

        IExecutor executor = new CommandExecutor();
        ICommand command = new TargetCommand(warrior, dragon);
        ICommand attack = new AttackCommand(warrior);
    }
}