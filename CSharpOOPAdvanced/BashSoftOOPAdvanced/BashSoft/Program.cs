using BashSoft.Executor.Contracts;
using BashSoft.Repository;

namespace BashSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repository = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());
            IInterpreter commandInterpreter = new CommandInterpreter(tester, repository, ioManager);
            IReader reader = new InputReader(commandInterpreter);

            reader.StartReadingCommands();
        }
    }
}