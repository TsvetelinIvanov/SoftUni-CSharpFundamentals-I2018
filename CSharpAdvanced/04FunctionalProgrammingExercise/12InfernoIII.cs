using System;
using System.Collections.Generic;
using System.Linq;

namespace _12InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<int> currentGems = new List<int>(gems);
            List<string> filters = new List<string>();

            string commandLine = string.Empty;
            while ((commandLine = Console.ReadLine()) != "Forge")
            {
                string[] commands = commandLine.Split(';');
                string command = commands[0];
                string condition = commands[1];
                string purpose = commands[2];

                if (command == "Exclude")
                {
                    filters.Add(condition + ":" + purpose);
                }
                else if (command == "Reverse")
                {
                    filters.Remove(condition + ":" + purpose);
                }
            }

            foreach (string filter in filters)
            {
                string[] command = filter.Split(':');
                string condition = command[0];
                int purpose = int.Parse(command[1]);

                switch (condition)
                {
                    case "Sum Left":
                        if (gems.Length > 0 && gems[0] == purpose)
                        {
                            currentGems.Remove(gems[0]);
                        }
                        for (int i = 1; i < gems.Length; i++)
                        {                           
                            if (gems[i] + gems[i - 1] == purpose)
                            {
                                currentGems.Remove(gems[i]);
                            }
                        }

                        break;
                    case "Sum Right":
                        if (gems.Length > 0 && gems[gems.Length - 1] == purpose)
                        {
                            currentGems.Remove(gems[gems.Length - 1]);
                        }
                        for (int i = 0; i < gems.Length - 1; i++)
                        {
                            if (gems[i] + gems[i + 1] == purpose)
                            {
                                currentGems.Remove(gems[i]);
                            }
                        }

                        break;
                    case "Sum Left Right":
                        if (gems.Length > 1)
                        {
                            if (gems[0] + gems[1] == purpose)
                            {
                                currentGems.Remove(gems[0]);
                            }

                            if (gems[gems.Length - 1] + gems[gems.Length - 2] == purpose)
                            {
                                currentGems.Remove(gems[gems.Length - 1]);
                            }
                        }
                        else if (gems.Length == 1)
                        {
                            if (gems[0] == purpose)
                            {
                                currentGems.Remove(gems[0]);
                            }
                        }

                        for (int i = 1; i < gems.Length - 1; i++)
                        {
                            if (gems[i - 1] + gems[i] + gems[i + 1]== purpose)
                            {
                                currentGems.Remove(gems[i]);
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(" ", currentGems));
        }
    }
}
