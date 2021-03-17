using System;
using System.Text;

public class Animal : ISoundProducable
{
    private const string ProducedSound = "Animal produce sound!";

    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender; 
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return $"{ProducedSound}";
    }

    public override string ToString()
    {
        StringBuilder animalBuilder = new StringBuilder();
        animalBuilder.AppendLine(this.GetType().Name)
            .AppendLine($"{this.Name} {this.Age} {this.Gender}")
            .Append(this.ProduceSound());

        return animalBuilder.ToString();
    }
}