public class Program
{
    static void Main(string[] args)
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        IAttackGroup group = new Group();
        group.AddMember(new Warrior("Torsten", 10, combatLogger));
        group.AddMember(new Warrior("Rolo", 15, combatLogger));
        
        ITarget dragon = new Dragon("Transylvanian White", 200, 25, combatLogger);

        IExecutor executor = new CommandExecutor();
        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand groupAttack = new GroupAttackCommand(group);
    }
}