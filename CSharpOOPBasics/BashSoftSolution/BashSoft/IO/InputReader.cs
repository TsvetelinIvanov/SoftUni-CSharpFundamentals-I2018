using System;

namespace BashSoft
{
    public static class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
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

                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}