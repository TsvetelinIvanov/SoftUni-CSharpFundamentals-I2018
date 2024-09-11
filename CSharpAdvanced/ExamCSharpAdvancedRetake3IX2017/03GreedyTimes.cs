using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> goldBag = new Dictionary<string, long>();
            Dictionary<string, long> gemBag = new Dictionary<string, long>();
            Dictionary<string, long> cashBag = new Dictionary<string, long>();
            long goldQuantity = 0;
            long gemQuantity = 0;
            long cashQuantity = 0;

            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safeInside = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < safeInside.Length; i += 2)
            {
                string itemName = safeInside[i];
                long itemQuantity = long.Parse(safeInside[i + 1]);
                string itemType = GetItemType(itemName);
                if (itemType == "Invalid")
                {
                    continue;
                }

                long bagFilling = goldQuantity + gemQuantity + cashQuantity;
                if (bagFilling > bagCapacity)
                {
                    continue;
                }                    

                if (itemType == "Gold")
                {
                    if (bagFilling + itemQuantity > bagCapacity)
                    {
                        continue;
                    }                        

                    if (!goldBag.ContainsKey(itemType))                        
                    {
                        goldBag[itemType] = 0;                        
                    }

                    goldBag[itemType] += itemQuantity;                    
                    goldQuantity += itemQuantity;
                }
                else if (itemType == "Gem")
                {
                    if (bagFilling + itemQuantity > bagCapacity || gemQuantity + itemQuantity > goldQuantity)
                    {
                        continue;
                    }                        

                    if (!gemBag.ContainsKey(itemName))
                    {
                        gemBag[itemName] = 0;
                    }

                    gemBag[itemName] += itemQuantity;
                    gemQuantity += itemQuantity;
                }
                else if (itemType == "Cash")
                {
                    if (bagFilling + itemQuantity > bagCapacity || cashQuantity + itemQuantity > gemQuantity)
                    {
                        continue;
                    }                        

                    if (!cashBag.ContainsKey(itemName))
                    {
                        cashBag[itemName] = 0;
                    }

                    cashBag[itemName] += itemQuantity;
                    cashQuantity += itemQuantity;
                }
            }

            if (goldBag.Any())
            {
                Console.WriteLine(ShowBagInside(goldBag, "Gold", goldQuantity));
                if (gemBag.Any())
                {
                    Console.WriteLine(ShowBagInside(gemBag, "Gem", gemQuantity));
                    if (cashBag.Any())
                    {
                        Console.WriteLine(ShowBagInside(cashBag, "Cash", cashQuantity));
                    }
                }
            }
        }

        private static string GetItemType(string itemName)
        {
            if (itemName.ToLower() == "gold")
            {
                return "Gold";
            }
            else if (itemName.ToLower().EndsWith("gem") && itemName.Length > 3)
            {
                return "Gem";
            }
            else if (itemName.Length == 3)
            {
                return "Cash";
            }
            else
            {
                return "Invalid";
            }
        }

        private static string ShowBagInside(Dictionary<string, long> bag, string name, long quantity)
        {
            StringBuilder bagInside = new StringBuilder();
            bagInside.AppendLine($"<{name}> ${quantity}");
            foreach (KeyValuePair<string, long> item in bag.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
            {
                bagInside.AppendLine($"##{item.Key} - {item.Value}");
            }

            return bagInside.ToString().Trim();
        }        
    }
}
