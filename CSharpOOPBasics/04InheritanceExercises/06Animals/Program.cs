using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        animals = ReadAnimals(animals);
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static List<Animal> ReadAnimals(List<Animal> animals)
    {
        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                string[] animalData = Console.ReadLine().Split();
                animals = ReadAnimalData(animals, animalData, animalType);                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        return animals;
    }

    private static List<Animal> ReadAnimalData(List<Animal> animals, string[] animalData, string animalType)
    {
        string name = animalData[0];
        int age = -1;
        bool isAge = int.TryParse(animalData[1], out age);
        if (!isAge)
        {
            throw new ArgumentException("Invalid input!");
        }

        string gender = null;
        if (animalData.Length >= 3)
        {
            gender = animalData[2];
        }

        switch (animalType)
        {
            case "Dog":
                Dog dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "Cat":
                Cat cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "Frog":
                Frog frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }

        return animals;
    }
}