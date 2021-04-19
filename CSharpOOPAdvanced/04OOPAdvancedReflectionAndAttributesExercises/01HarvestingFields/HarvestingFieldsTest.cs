using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _01HarvestingFields
{
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType("_01HarvestingFields.HarvestingFields");
            FieldInfo[] allFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint;
                switch (command)
                {
                    case "public":
                        fieldsToPrint = allFields.Where(f => f.IsPublic);
                        break;
                    case "protected":
                        fieldsToPrint = allFields.Where(f => f.IsFamily);
                        break;
                    case "private":
                        fieldsToPrint = allFields.Where(f => f.IsPrivate);
                        break;
                    case "all":
                        fieldsToPrint = allFields;
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }

                foreach (FieldInfo field in fieldsToPrint)
                {
                    Print(field);
                }
            }
        }

        private static void Print(FieldInfo field)
        {
            string accessModifier = field.Attributes.ToString().ToLower();
            if (accessModifier == "family")
            {
                accessModifier = "protected";
            }

            string fieldString = $"{accessModifier} {field.FieldType.Name} {field.Name}";

            Console.WriteLine(fieldString);
        }
    }
}