using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }    

    //public override bool Equals(object obj)
    //{
    //    if (obj is Person other)
    //    {
    //        return this.Name == other.Name && this.Age == other.Age;
    //    }

    //    return false;
    //}

    //public override int GetHashCode()
    //{
    //    return this.Name.GetHashCode() + this.Age.GetHashCode();
    //}

    public int CompareTo(Person otherPerson)
    {
        int comparison = this.Name.CompareTo(otherPerson.Name);

        return comparison == 0 ? this.Age.CompareTo(otherPerson.Age) : comparison;
    }
}