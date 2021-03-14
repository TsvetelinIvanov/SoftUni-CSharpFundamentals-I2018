public class Cat
{
    private string name;
    private string breed;
    private double characteristicValue;

    public Cat(string name, string breed, double characteristicValue)
    {
        this.Name = name;
        this.Breed = breed;
        this.CharacteristicValue = characteristicValue;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public double CharacteristicValue
    {
        get { return this.characteristicValue; }
        set { this.characteristicValue = value; }
    }

    public override string ToString()
    {
        if (this.Breed == "Cymric")
        {
            return $"{this.Breed} {this.Name} {this.CharacteristicValue:f2}";
        }
        else
        {
            return $"{this.Breed} {this.Name} {(int)this.CharacteristicValue}";
        }
    }
}