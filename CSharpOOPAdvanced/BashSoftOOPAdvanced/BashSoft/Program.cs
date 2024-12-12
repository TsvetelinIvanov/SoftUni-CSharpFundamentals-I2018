using BashSoft.IO;
﻿using BashSoft.Judge;
﻿using BashSoft.Executor;
using BashSoft.Repository;
﻿using BashSoft.Executor.Contracts;

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
