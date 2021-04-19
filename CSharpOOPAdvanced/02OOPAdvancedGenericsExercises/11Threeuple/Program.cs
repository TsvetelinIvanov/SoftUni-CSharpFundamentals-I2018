using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] personData = Console.ReadLine().Split();
        string firstName = personData[0];
        string lastName = personData[1];
        string fullName = firstName + " " + lastName;
        string address = personData[2];
        string town = personData[3];
        Threeuple<string, string, string> personThreeuple = new Threeuple<string, string, string>(fullName, address, town);
        Console.WriteLine(personThreeuple);

        string[] drinkerData = Console.ReadLine().Split();
        string drinkerName = drinkerData[0];
        int litersOfBeer = int.Parse(drinkerData[1]);
        bool drunkOrNot = DrunkOrNot(drinkerData[2]);
        Threeuple<string, int, bool> drinkerThreeuple = new Threeuple<string, int, bool>(drinkerName, litersOfBeer, drunkOrNot);
        Console.WriteLine(drinkerThreeuple);

        string[] bankBalanceData = Console.ReadLine().Split();
        string depositorName = bankBalanceData[0];
        double bankBalance = double.Parse(bankBalanceData[1]);
        string bankName = bankBalanceData[2];
        Threeuple<string, double, string> bankBalanceThreeuple = new Threeuple<string, double, string>(depositorName, bankBalance, bankName);
        Console.WriteLine(bankBalanceThreeuple);
    }

    private static bool DrunkOrNot(string drunkOrNot)
    {
        if (drunkOrNot == "drunk")
        {
            return true;
        }
        else
        {
            return false;
        }
        //else if (drunkOrNot == "not")
        //{
        //    return false;
        //}
        //else
        //{
        //    throw new ArgumentException("Wrong input!");
        //}
    }
}