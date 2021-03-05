using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string commandLine = string.Empty;
            while ((commandLine = Console.ReadLine()) != "Party!")
            {
                string[] commands = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string condition = commands[1];
                string purpose = commands[2];              

                switch (command)
                {
                    case "Remove":
                        switch (condition)
                        {
                            case "StartsWith":
                                Func<string, bool> startsFilter = n => !n.StartsWith(purpose);
                                names = names.Where(startsFilter).ToList();
                                break;
                            case "EndsWith":
                                Func<string, bool> endsFilter = n => !n.EndsWith(purpose);
                                names = names.Where(endsFilter).ToList();
                                break;
                            case "Length":
                                Func<string, bool> lengthFilter = n => n.Length != int.Parse(purpose);
                                names = names.Where(lengthFilter).ToList();
                                break;
                        }

                        break;
                    case "Double":
                        switch (condition)
                        {
                            case "StartsWith":
                                Func<string, bool> startsFilter = n => n.StartsWith(purpose);
                                for (int i = 0; i < names.Count; i++)
                                {
                                    if (startsFilter(names[i]))
                                    {
                                        names.Insert(i + 1, names[i]);
                                        i++;
                                    }
                                }
                                
                                break;
                            case "EndsWith":
                                Func<string, bool> endsFilter = n => n.EndsWith(purpose);
                                for (int i = 0; i < names.Count; i++)
                                {
                                    if (endsFilter(names[i]))
                                    {
                                        names.Insert(i + 1, names[i]);
                                        i++;
                                    }
                                }

                                break;
                            case "Length":
                                Func<string, bool> lengthFilter = n => n.Length == int.Parse(purpose);
                                for (int i = 0; i < names.Count; i++)
                                {
                                    if (lengthFilter(names[i]))
                                    {
                                        names.Insert(i + 1, names[i]);
                                        i++;
                                    }
                                }

                                break;
                        }

                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
