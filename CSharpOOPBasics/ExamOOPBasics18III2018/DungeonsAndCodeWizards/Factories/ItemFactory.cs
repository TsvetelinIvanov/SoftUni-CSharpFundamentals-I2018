using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{ type }\"!");
            }
        }

        //With reflection:
        //public Item CreateItem(string name)
        //{
        //    Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == name);
        //    if (type == null)
        //    {
        //        throw new ArgumentException($"Invalid item \"{name}\"!");
        //    }

        //    Item item = (Item)Activator.CreateInstance(type);

        //    return item;
        //}
    }
}