using System;

public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        ExecuteCommand(linkedList);
        PrintResult(linkedList);
    }

    private static void ExecuteCommand(LinkedList<int> linkedList)
    {
        int commandsNumber = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsNumber; i++)
        {
            string[] inputLine = Console.ReadLine().Split();
            string command = inputLine[0];
            int number = int.Parse(inputLine[1]);

            switch (command)
            {
                case "Add":
                    linkedList.Add(number);
                    break;
                case "Remove":
                    linkedList.Remove(number);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }

    private static void PrintResult(LinkedList<int> linkedList)
    {
        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}