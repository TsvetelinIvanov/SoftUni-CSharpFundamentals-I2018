using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public List<Person> FamilyMembers
    {
        get { return this.familyMembers; }
        set { this.familyMembers = value; }
    }

    public void AddFamilyMember(Person person)
    {
        this.familyMembers.Add(person);
    }

    public Person GetOldestMember()
    {
        Person oldestMember = familyMembers.OrderByDescending(m => m.Age).First();
        
        return oldestMember;
    }
}
