using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string command = commandArgs[0];
            switch (command)
            {
                case "Push":
                    string[] args = commandArgs.Skip(1).ToArray();
                    stack.Push(args);
                    break;
                case "Pop":
                    stack.Pop();
                    break;
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, stack));
        Console.WriteLine(string.Join(Environment.NewLine, stack));
    }
}