using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pizzaName = Console.ReadLine().Split().Last();
            Pizza pizza = new Pizza(pizzaName);
            
            Dough dough = ReadDoughInput();
            pizza.Dough = dough;
            
            string toppingInput;
            while ((toppingInput = Console.ReadLine()) != "END")
            {
                Topping topping = ReadToppingInput(toppingInput);
                pizza.AddTopping(topping);                
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static Dough ReadDoughInput()
    {
        string[] doughInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string flourType = doughInput[1];
        string bakingTechiques = doughInput[2];
        double weight = double.Parse(doughInput[3]);
        Dough dough = new Dough(flourType, bakingTechiques, weight);

        return dough;
    }

    private static Topping ReadToppingInput(string toppingInput)
    {
        string[] toppingData = toppingInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string toppingType = toppingData[1];
        double toppingWeight = double.Parse(toppingData[2]);
        Topping topping = new Topping(toppingType, toppingWeight);

        return topping;
    }    
}
