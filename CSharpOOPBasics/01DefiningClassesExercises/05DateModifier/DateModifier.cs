using System;

public class DateModifier
{
    private DateTime firstDate;
    private DateTime secondDate;

    public DateTime FirstDate
    {
        get { return this.firstDate; }
        set { this.firstDate = value; }
    }

    public DateTime SecondDate
    {
        get { return this.secondDate; }
        set { this.secondDate = value; }
    }

    public long GiveDiferenceInDays()
    {
        long diferenceInDays = Math.Abs((secondDate - firstDate).Days);
        
        return diferenceInDays;
    }
}