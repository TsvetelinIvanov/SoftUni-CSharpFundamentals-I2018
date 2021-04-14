public class Program
{
    static void Main(string[] args)
    {
        IInputReader consoleReader = new ConsoleReader();
        IOutputWriter consoleWriter = new ConsoleWriter();
        IDatabase database = new Database();
        IGameController gameController = new GameController(database);
        IEngine engine = new Engine(consoleReader, consoleWriter, gameController);
        engine.Run();
    }
}