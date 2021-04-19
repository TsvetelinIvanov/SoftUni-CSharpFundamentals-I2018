using System;

public class CustomList
{
    public void ExecuteComand()
    {
        Box<string> box = new Box<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    string element = commandArgs[1];
                    box.Add(element);
                    break;
                case "Remove":
                    int index = int.Parse(commandArgs[1]);
                    box.Remove(index);
                    break;
                case "Contains":
                    element = commandArgs[1];
                    Console.WriteLine(box.Contains(element));
                    break;
                case "Swap":
                    int swappedIndex = int.Parse(commandArgs[1]);
                    int swappingIndex = int.Parse(commandArgs[2]);
                    box.Swap(swappedIndex, swappingIndex);
                    break;
                case "Greater":
                    string elementForComparing = commandArgs[1];
                    int greaterElementsCount = box.CountGreaterThan(elementForComparing);
                    Console.WriteLine(greaterElementsCount);
                    break;
                case "Min":
                    string minElement = box.Min();
                    Console.WriteLine(minElement);
                    break;
                case "Max":
                    string maxElement = box.Max();
                    Console.WriteLine(maxElement);
                    break;
                case "Print":
                    Console.WriteLine(box);
                    break;
                case "Sort":
                    box.Sort();
                    break;
                case "Iterate":
                    Console.WriteLine(string.Join(Environment.NewLine, box));
                    break;
                default:
                    throw new ArgumentException("Invalid Command!");
            }
        }
    }
}