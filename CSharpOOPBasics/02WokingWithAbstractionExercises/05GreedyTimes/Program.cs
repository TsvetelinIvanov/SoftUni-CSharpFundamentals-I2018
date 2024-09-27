using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] safeContent = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();
        
        for (int i = 0; i < safeContent.Length; i += 2)
        {
            string itemType = safeContent[i];
            long itemQuantity = long.Parse(safeContent[i + 1]);

            string valueType = string.Empty;
            if (itemType.Length == 3)
            {
                valueType = "Cash";
            }
            else if (itemType.ToLower().EndsWith("gem"))
            {
                valueType = "Gem";
            }
            else if (itemType.ToLower() == "gold")
            {
                valueType = "Gold";
            }

            if (valueType == "")
            {
                continue;
            }
            else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + itemQuantity)
            {
                continue;
            }

            switch (valueType)
            {
                case "Gem":
                    if (!bag.ContainsKey(valueType))
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
                    else if (bag[valueType].Values.Sum() + itemQuantity > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }

                    break;
                case "Cash":
                    if (!bag.ContainsKey(valueType))
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
                    else if (bag[valueType].Values.Sum() + itemQuantity > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }

                    break;
            }

            if (!bag.ContainsKey(valueType))
            {
                bag[valueType] = new Dictionary<string, long>();
            }

            if (!bag[valueType].ContainsKey(itemType))
            {
                bag[valueType][itemType] = 0;
            }

            bag[valueType][itemType] += itemQuantity;            
        }

        foreach (KeyValuePair<string, Dictionary<string, long>> valueType in bag)
        {
            Console.WriteLine($"<{valueType.Key}> ${valueType.Value.Values.Sum()}");
            foreach (KeyValuePair<string, long> currentValue in valueType.Value.OrderByDescending(vt => vt.Key).ThenBy(vt => vt.Value))
            {
                Console.WriteLine($"##{currentValue.Key} - {currentValue.Value}");
            }
        }
    }
}
