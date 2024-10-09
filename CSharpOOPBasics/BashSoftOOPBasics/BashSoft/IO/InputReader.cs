using System;
using BashSoft.Executor;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class InputReader
    {
        private const string EndCommand = "quit";

        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}>");
            string input = Console.ReadLine();
            input = input.Trim();

            while (true)
            {
                if (input == EndCommand)
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
                
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}
