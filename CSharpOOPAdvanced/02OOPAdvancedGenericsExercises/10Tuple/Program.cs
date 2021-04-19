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
        Tuple<string, string> personTuple = new Tuple<string, string>(fullName, address);
        Console.WriteLine(personTuple);

        string[] drinkerData = Console.ReadLine().Split();
        string name = drinkerData[0];
        int litersOfBeer = int.Parse(drinkerData[1]);
        Tuple<string, int> drinkerTuple = new Tuple<string, int>(name, litersOfBeer);
        Console.WriteLine(drinkerTuple);

        string[] numberData = Console.ReadLine().Split();
        int intNumber = int.Parse(numberData[0]);
        double doubleNumber = double.Parse(numberData[1]);
        Tuple<int, double> numberTuple = new Tuple<int, double>(intNumber, doubleNumber);
        Console.WriteLine(numberTuple);
    }
}