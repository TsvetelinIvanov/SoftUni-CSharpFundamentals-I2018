using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();
        string input;
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            List<string> arguments = input.Split().ToList();
            string command = arguments[0];
            arguments = arguments.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(arguments));
                    break;
            }            
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}