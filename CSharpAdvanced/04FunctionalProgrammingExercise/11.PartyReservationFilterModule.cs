using System;
using System.Collections.Generic;
using System.Linq;

namespace _11PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> filters = new List<string>();
            string commandLine = string.Empty;
            while ((commandLine = Console.ReadLine()) != "Print")
            {
                string[] commands = commandLine.Split(';');
                string command = commands[0];
                string condition = commands[1];
                string purpose = commands[2];

                if (command == "Add filter")
                {
                    filters.Add(condition + " " + purpose);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(condition + " " + purpose);
                }
            }

            foreach (string filter in filters)
            {
                string[] command = filter.Split(' ');                
                string condition = command[0];
                string purpose = command[command.Length - 1];
                switch (condition)
                {
                    case "Starts":
                        Func<string, bool> startsFilter = n => !n.StartsWith(purpose);
                        names = names.Where(startsFilter).ToArray();
                        break;
                    case "Ends":
                        Func<string, bool> endsFilter = n => !n.EndsWith(purpose);
                        names = names.Where(endsFilter).ToArray();
                        break;
                    case "Contains":
                        Func<string, bool>containsFilter = n => !n.Contains(purpose);
                        names = names.Where(containsFilter).ToArray();
                        break;
                    case "Length":
                        Func<string, bool> lengthFilter = n => n.Length != int.Parse(purpose);
                        names = names.Where(lengthFilter).ToArray();
                        break;
                }
            }

            if (names.Length > 0)
            {
                Console.WriteLine(string.Join(" ", names));
            }
        }
    }
}
