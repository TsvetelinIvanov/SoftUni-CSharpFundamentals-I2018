using System.Collections.Generic;

public class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person firstPerson, Person secondPerson)
    {
        return firstPerson.CompareTo(secondPerson) == 0;
    }

    public int GetHashCode(Person person)
    {
        return $"{person.Name} {person.Age}".GetHashCode();
    }
}