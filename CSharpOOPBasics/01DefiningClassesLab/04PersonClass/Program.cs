using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandArgs[0];
            switch (command)
            {
                case "Create":
                    Create(commandArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(commandArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(commandArgs, accounts);
                    break;
                case "Print":
                    Print(commandArgs, accounts);
                    break;
            }
        }
    }

    private static void Create(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Id = id;
            accounts.Add(id, bankAccount);
        }
    }

    private static void Deposit(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        decimal amount = decimal.Parse(commandArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Deposit(amount);
        }
    }

    private static void Withdraw(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        decimal amount = decimal.Parse(commandArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (accounts[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            accounts[id].Withdraw(amount);
        }
    }

    private static void Print(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }
    }            
}