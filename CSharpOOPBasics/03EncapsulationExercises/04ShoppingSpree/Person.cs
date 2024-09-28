using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> productsBag;

    public Person()
    {
        this.ProductsBag = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        this.Name = name;
        this.Money = money;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> ProductsBag
    {
        get { return this.productsBag; }
        set { this.productsBag = value; }
    }

    public override string ToString()
    {
        StringBuilder boughtProducts = new StringBuilder();
        if (this.ProductsBag.Count > 0)
        {
            boughtProducts.AppendFormat("{0} - {1}", this.Name, string.Join(", ", this.ProductsBag.Select(p => p.Name)));
        }
        else
        {
            boughtProducts.Append($"{this.Name} - Nothing bought");
        }

        return boughtProducts.ToString();
    }
}
