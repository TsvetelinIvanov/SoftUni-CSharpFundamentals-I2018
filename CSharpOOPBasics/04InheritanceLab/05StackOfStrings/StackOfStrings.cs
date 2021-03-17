using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string element)
    {
        this.data.Add(element);
    }

    public string Peek()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = this.data.Last();
        }

        return element;
    }

    public string Pop()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = this.data.Last();
            this.data.Remove(element);
        }

        return element;
    }
}