using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal = ReadAnimal(input);
            Food food = ReadFood();

            animal.MakeSound();
            animal.TryEatFood(food);
            
            animals.Add(animal);
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }    

    private static Animal ReadAnimal(string input)
    {
        string[] animalData = input.Split();
        string type = animalData[0];
        string name = animalData[1];
        double weight = double.Parse(animalData[2]);
        string livingRegionOrWingSize = animalData[3];

        Animal animal = null;
        switch (type)
        {
            case "Hen":
                double henWingSize = double.Parse(livingRegionOrWingSize);
                animal = new Hen(name, weight, henWingSize);
                break;
            case "Owl":
                double owlWingSize = double.Parse(livingRegionOrWingSize);
                animal = new Owl(name, weight, owlWingSize);
                break;
            case "Mouse":
                animal = new Mouse(name, weight, livingRegionOrWingSize);
                break;
            case "Dog":
                animal = new Dog(name, weight, livingRegionOrWingSize);
                break;
            case "Cat":
                string catBreed = animalData[4];
                animal = new Cat(name, weight, livingRegionOrWingSize, catBreed);
                break;
            case "Tiger":
                string tigerBreed = animalData[4];
                animal = new Tiger(name, weight, livingRegionOrWingSize, tigerBreed);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }

        return animal;
    }

    private static Food ReadFood()
    {
        string[] foodData = Console.ReadLine().Split();
        string type = foodData[0];
        int quantity = int.Parse(foodData[1]);

        Food food = null;
        switch (type)
        {
            case "Vegetable":
                food = new Vegetable(quantity);
                break;
            case "Fruit":
                food = new Fruit(quantity);
                break;
            case "Meat":
                food = new Meat(quantity);
                break;
            case "Seeds":
                food = new Seeds(quantity);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }

        return food;
    }
}
