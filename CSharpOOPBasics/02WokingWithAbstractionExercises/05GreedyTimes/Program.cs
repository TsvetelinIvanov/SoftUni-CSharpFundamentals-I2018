using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] safeInners = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();
        
        for (int i = 0; i < safeInners.Length; i += 2)
        {
            string itemType = safeInners[i];
            long itemQuantity = long.Parse(safeInners[i + 1]);

            string worthinesType = string.Empty;
            if (itemType.Length == 3)
            {
                worthinesType = "Cash";
            }
            else if (itemType.ToLower().EndsWith("gem"))
            {
                worthinesType = "Gem";
            }
            else if (itemType.ToLower() == "gold")
            {
                worthinesType = "Gold";
            }

            if (worthinesType == "")
            {
                continue;
            }
            else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + itemQuantity)
            {
                continue;
            }

            switch (worthinesType)
            {
                case "Gem":
                    if (!bag.ContainsKey(worthinesType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (itemQuantity > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[worthinesType].Values.Sum() + itemQuantity > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }

                    break;
                case "Cash":
                    if (!bag.ContainsKey(worthinesType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (itemQuantity > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[worthinesType].Values.Sum() + itemQuantity > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }

                    break;
            }

            if (!bag.ContainsKey(worthinesType))
            {
                bag[worthinesType] = new Dictionary<string, long>();
            }

            if (!bag[worthinesType].ContainsKey(itemType))
            {
                bag[worthinesType][itemType] = 0;
            }

            bag[worthinesType][itemType] += itemQuantity;            
        }

        foreach (KeyValuePair<string, Dictionary<string, long>> worthinesType in bag)
        {
            Console.WriteLine($"<{worthinesType.Key}> ${worthinesType.Value.Values.Sum()}");
            foreach (KeyValuePair<string, long> worthines in worthinesType.Value.OrderByDescending(wt => wt.Key).ThenBy(wt => wt.Value))
            {
                Console.WriteLine($"##{worthines.Key} - {worthines.Value}");
            }
        }
    }
}