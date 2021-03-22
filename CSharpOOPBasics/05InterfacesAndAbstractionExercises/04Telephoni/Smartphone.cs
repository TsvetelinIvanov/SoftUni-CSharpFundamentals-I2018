using System;
using System.Text.RegularExpressions;

public class Smartphone : ICallingable, IBrowseable
{
    public void Call(string phoneNumber)
    {
        if (Regex.IsMatch(phoneNumber, @"^\d+$"))
        {
            Console.WriteLine("Calling... " + phoneNumber);
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
    }

    public void Browse(string worldWideWeb)
    {
        if (Regex.IsMatch(worldWideWeb, @"^[^\d]*$"))
        {
            Console.WriteLine($"Browsing: {worldWideWeb}!");
        }
        else
        {
            Console.WriteLine("Invalid URL!");
        }
    }
}