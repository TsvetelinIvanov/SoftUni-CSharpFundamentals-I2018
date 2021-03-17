using System;

public class Program
{
    static void Main(string[] args)
    {
        string mainPersonInput = Console.ReadLine();
        FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            ParseInput(input, familyTreeBuilder);
        }

        string familyTree = familyTreeBuilder.Build();
        Console.WriteLine(familyTree);
    }

    private static void ParseInput(string input, FamilyTreeBuilder familyTreeBuilder)
    {
        string[] personData = input.Split(" - ");
        if (personData.Length > 1)
        {
            GetParentAndChild(familyTreeBuilder, personData);
        }
        else
        {
            GetDataForPerson(familyTreeBuilder, personData);
        }
    }

    private static void GetParentAndChild(FamilyTreeBuilder familyTreeBuilder, string[] personData)
    {
        string parentData = personData[0];
        string childData = personData[1];
        familyTreeBuilder.SetParentChildRelation(parentData, childData);
    }

    private static void GetDataForPerson(FamilyTreeBuilder familyTreeBuilder, string[] personData)
    {
        personData = personData[0].Split();
        string name = personData[0] + " " + personData[1];
        string birthday = personData[2];
        familyTreeBuilder.SetFullInfo(name, birthday);
    }
}