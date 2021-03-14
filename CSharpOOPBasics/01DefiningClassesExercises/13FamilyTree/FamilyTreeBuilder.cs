using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    private List<Person> FamilyTree { get; set; }
    private Person MainPerson { get; set; }

    public FamilyTreeBuilder(string mainPersonImput)
    {
        FamilyTree = new List<Person>();
        MainPerson = Person.CreatePerson(mainPersonImput);
        FamilyTree.Add(MainPerson);
    }

    public string Build()
    {
        StringBuilder buildedResult = new StringBuilder();
        buildedResult.AppendLine(this.MainPerson.ToString());
        buildedResult.AppendLine("Parents:");
        foreach (Person parent in this.MainPerson.Parents)
        {
            buildedResult.AppendLine(parent.ToString());
        }

        buildedResult.AppendLine("Children:");
        foreach (Person child in this.MainPerson.Children)
        {
            buildedResult.AppendLine(child.ToString());
        }

        string finalResult = buildedResult.ToString().TrimEnd();

        return finalResult;
    }

    private Person FindOrCreate(string personImput)
    {
        Person person = this.FamilyTree.FirstOrDefault(p => p.Name == personImput || p.Birthday == personImput);
        if (person == null)
        {
            person = Person.CreatePerson(personImput);
            this.FamilyTree.Add(person);
        }

        return person;
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

    public void SetFullInfo(string name, string birthday)
    {
        Person person = this.FamilyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            this.FamilyTree.Add(person);
        }

        person.Name = name;
        person.Birthday = birthday;
        this.CheckForDuplicate(person);
    }

    private void CheckForDuplicate(Person person)
    {
        string name = person.Name;
        string birthday = person.Birthday;
        Person duplicate = this.FamilyTree.Where(p => p.Name == name || p.Birthday == birthday)
            .Skip(1).FirstOrDefault();
        if (duplicate != null)
        {
            this.RemoveDuplicate(person, duplicate);
        }
    }

    private void RemoveDuplicate(Person person, Person duplicate)
    {
        this.FamilyTree.Remove(duplicate);
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