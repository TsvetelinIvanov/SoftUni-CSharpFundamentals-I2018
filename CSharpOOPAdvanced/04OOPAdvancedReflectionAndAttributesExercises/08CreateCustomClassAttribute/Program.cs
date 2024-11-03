using System;

public class Program
{
    static void Main(string[] args)
    {
        Type classType = typeof(Weapon);
        object[] attributes = classType.GetCustomAttributes(false);
        foreach (object attribute in attributes)
        {
            ClassAttribute classAttribute = attribute as ClassAttribute;
            if (classAttribute != null)
            {
                string command;
                while((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {classAttribute.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {classAttribute.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {classAttribute.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {string.Join(", ", classAttribute.Reviewers)}");
                            break;
                    }
                }
            }
        }        
    }
}
