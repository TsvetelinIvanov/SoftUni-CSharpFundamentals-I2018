using System;
using System.Collections.Generic;

public delegate void OnMeloLemonMelonEatenHandler(INinja ninja, EventArgs args);

public class Ninja : GameObject, INinja
{
    private string name;
    private int power;
    private int stamina;
    private List<IVegetable> collectedVegetables;      

    public Ninja(IMatrixPosition position, string name) : base(position, name[0])
    {
        this.Name = name;
        this.Power = 1;
        this.Stamina = 1;
        this.collectedVegetables = new List<IVegetable>();
    }

    public event OnMeloLemonMelonEatenHandler MeloLemonMelonEaten;

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Power
    {
        get { return this.power; }
        private set
        {
            //value = value < 0 ? 0 : value;
            if (value < 0)
            {
                value = 0;
            }            

            this.power = value;
        }
    }

    public int Stamina
    {
        get { return this.stamina; }
        private set
        {
            //value = value < 0 ? 0 : value;
            if (value < 0)
            {
                value = 0;
            }
            
            this.stamina = value;
        }
    }    

    public void ReduceStamina()
    {
        this.Stamina -= 1;
    }

    public void CollectVegetable(IVegetable vegetable)
    {
        this.collectedVegetables.Add(vegetable);
    }

    public void EatVegetables()
    {
        foreach (var vegetable in this.collectedVegetables)
        {
            if (vegetable.CharValue.Equals('*'))
            {
                if (this.MeloLemonMelonEaten != null)
                {
                    this.MeloLemonMelonEaten(this, new EventArgs());
                }
            }

            this.Power += vegetable.PowerBonus;
            this.Stamina += vegetable.StaminaBonus;
        }

        this.collectedVegetables.Clear();
    }   

    public void Move(IMatrixPosition newPosition)
    {
        if (newPosition == null)
        {
            this.Stamina--;
            return;
        }

        this.Position = newPosition;
        this.Stamina--;
    }

    //private bool IsInMatrix(char[][] matrix, int row, int col)
    //{
    //    return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
    //}    

    public override string ToString()
    {
        return $"Winner: {this.Name}{Environment.NewLine}Power: {this.Power}{Environment.NewLine}" +
            $"Stamina: {this.Stamina}";
    }
}