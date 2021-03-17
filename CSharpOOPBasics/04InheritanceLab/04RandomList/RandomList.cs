using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    Random random = new Random();

    public string RandomString()
    {
        string removedRandomString = null;
        if (this.Count > 0)
        {
            int randonIndex = random.Next(0, this.Count - 1);
            removedRandomString = this[randonIndex];
            this.RemoveAt(randonIndex);
        }

        return removedRandomString;
    }
}