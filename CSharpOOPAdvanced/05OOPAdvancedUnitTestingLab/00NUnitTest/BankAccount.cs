using System;

public class BankAccount
{
    public BankAccount(decimal amount)
    {
        this.Amount = amount;
    }

    public int Balance { get; private set; }

    public decimal Amount { get; set; }

    public void Deposit(int amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (Balance < amount)
        {
            throw new Exception("Insufficient funds!");
        }

        this.Balance -= amount;
    }
}