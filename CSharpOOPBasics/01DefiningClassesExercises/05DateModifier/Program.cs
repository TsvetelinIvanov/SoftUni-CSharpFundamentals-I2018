using System;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        string firstDateString = Console.ReadLine();
        string secondDateString = Console.ReadLine();
        DateModifier dateModifier = new DateModifier();
        dateModifier.FirstDate = DateTime.ParseExact(firstDateString, "yyyy MM dd", CultureInfo.InvariantCulture);
        dateModifier.SecondDate = DateTime.ParseExact(secondDateString, "yyyy MM dd", CultureInfo.InvariantCulture);
        long diferenceInDays = dateModifier.GiveDiferenceInDays();
        Console.WriteLine(diferenceInDays);
    }
}