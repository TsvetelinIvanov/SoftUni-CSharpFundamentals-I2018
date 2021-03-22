using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<IIDable> ids = new List<IIDable>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] citizenData = input.Split();

            if (citizenData.Length == 2)
            {
                string model = citizenData[0];
                string id = citizenData[1];
                Robot robot = new Robot(model, id);
                ids.Add(robot);
            }
            else if (citizenData.Length == 3)
            {
                string name = citizenData[0];
                int age = int.Parse(citizenData[1]);
                string id = citizenData[2];
                Person person = new Person(name, age, id);
                ids.Add(person);
            }
        }

        string fakeIdEnd = Console.ReadLine();
        List<IIDable> fakeIds = ids.Where(i => i.Id.EndsWith(fakeIdEnd)).ToList();
        foreach (IIDable fakeId in fakeIds)
        {
            Console.WriteLine(fakeId.Id);
        }
    }
}