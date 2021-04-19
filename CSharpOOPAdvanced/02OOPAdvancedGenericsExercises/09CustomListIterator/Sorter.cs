using System;
using System.Collections;
using System.Collections.Generic;

public class Sorter<T> : IEnumerable<T> where T : IComparable
{    
    public static void Sort(Box<T> box)
    {
        box.Sort();        
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}