using System;
using System.Collections.Generic;
using System.Linq;

namespace _04HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, string>> names = new Dictionary<string, SortedDictionary<string, string>>();
            int targetIndex = int.Parse(Console.ReadLine());
            string inputInfo = string.Empty;
            while ((inputInfo = Console.ReadLine()) != "end transmissions")
            {
                string[] personInfo = inputInfo.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                if (!names.ContainsKey(name))
                {
                    names[name] = new SortedDictionary<string, string>();
                }

                for (int i = 1; i < personInfo.Length; i++)
                {
                    string personKey = personInfo[i].Split(':').First();
                    string personValue = personInfo[i].Split(':').Last();

                    if (!names[name].ContainsKey(personKey))
                    {
                        names[name][personKey] = string.Empty;
                    }

                    names[name][personKey] = personValue;
                }
            }

            string targetName = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last();

            int infoIndex = 0;
            Console.WriteLine($"Info on {targetName}:");
            foreach (KeyValuePair<string, string> info in names[targetName])
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
                infoIndex += info.Key.Length;
                infoIndex += info.Value.Length;
            }

            Console.WriteLine("Info index: " + infoIndex);
            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }
    }
}
