using System;

public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get { return this.codeNumber; }
        set { this.codeNumber = value; }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}{Environment.NewLine}" +
            $"Code Number: {this.CodeNumber}";
    }
}