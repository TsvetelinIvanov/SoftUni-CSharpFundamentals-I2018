using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    private List<Person> familyTree { get; set; }
    private Person mainPerson { get; set; }

    public FamilyTreeBuilder(string mainPersonImput)
    {
        this.familyTree = new List<Person>();
        this.mainPerson = Person.CreatePerson(mainPersonImput);
        this.familyTree.Add(mainPerson);
    }

    public string Build()
    {
        StringBuilder familyTreeResultBuilder = new StringBuilder();
        familyTreeResultBuilder.AppendLine(this.mainPerson.ToString());
        familyTreeResultBuilder.AppendLine("Parents:");
        foreach (Person parent in this.mainPerson.Parents)
        {
            familyTreeResultBuilder.AppendLine(parent.ToString());
        }

        familyTreeResultBuilder.AppendLine("Children:");
        foreach (Person child in this.mainPerson.Children)
        {
            familyTreeResultBuilder.AppendLine(child.ToString());
        }

        string familyTreeResult = familyTreeResultBuilder.ToString().TrimEnd();

        return familyTreeResult;
    }
    
    public void SetParentChildRelation(string parentInput, string childInput)
    {
        Person parent = FindOrCreate(parentInput);
        SetChild(parent, childInput);
    }

    public void SetChild(Person parent, string childInput)
    {
        Person child = FindOrCreate(childInput);
        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    private Person FindOrCreate(string personImput)
    {
        Person person = this.familyTree.FirstOrDefault(p => p.Name == personImput || p.Birthday == personImput);
        if (person == null)
        {
            person = Person.CreatePerson(personImput);
            this.familyTree.Add(person);
        }

        return person;
    }

    public void SetFullInfo(string name, string birthday)
    {
        Person person = this.familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            this.familyTree.Add(person);
        }

        person.Name = name;
        person.Birthday = birthday;
        this.CheckForDuplicate(person);
    }

    private void CheckForDuplicate(Person person)
    {
        string name = person.Name;
        string birthday = person.Birthday;
        Person duplicate = this.familyTree.Where(p => p.Name == name || p.Birthday == birthday).Skip(1).FirstOrDefault();
        if (duplicate != null)
        {
            this.RemoveDuplicate(person, duplicate);
        }
    }

    private void RemoveDuplicate(Person person, Person duplicate)
    {
        this.familyTree.Remove(duplicate);
        person.Parents.AddRange(duplicate.Parents);
        foreach (Person parent in duplicate.Parents)
        {
            ReplaceDuplicate(person, duplicate, parent.Children);
        }

        person.Children.AddRange(duplicate.Children);
        foreach (Person child in duplicate.Children)
        {
            ReplaceDuplicate(person, duplicate, child.Parents);
        }
    }

    private static void ReplaceDuplicate(Person original, Person duplicate, List<Person> collection)
    {
        int duplicateIndex = collection.IndexOf(duplicate);
        if (duplicateIndex > -1)
        {
            collection[duplicateIndex] = original;
        }
        else
        {
            collection.Add(original);
        }
    }
}
