using System;

public class Sorter<T> where T : IComparable<T>
{
    public static void Sort(Box<T> box)
    {
        box.Sort();
    }
}