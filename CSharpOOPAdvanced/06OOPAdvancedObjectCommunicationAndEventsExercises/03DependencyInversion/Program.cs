using System;

public class Program
{
    static void Main(string[] args)
    {
        AdditionStrategy additionStrategy = new AdditionStrategy();
        ICalculator calculator = new Calculator(additionStrategy);

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputData = input.Split();
            if (inputData[0] == "mode")
            {
                char operator1 = char.Parse(inputData[1]);
                ICalculationStrategy strategy = null;

                switch (operator1)
                {
                    case '+':
                        strategy = new AdditionStrategy();
                        break;
                    case '-':
                        strategy = new SubtractionStrategy();
                        break;
                    case '*':
                        strategy = new MultiplicationStrategy();
                        break;
                    case '/':
                        strategy = new DivisionStrategy();
                        break;
                }

                calculator.ChangeStrategy(strategy);
            }
            else
            {
                int left = int.Parse(inputData[0]);
                int right = int.Parse(inputData[1]);
                int result = calculator.PerformCalculation(left, right);
                Console.WriteLine(result);
            }
        }
    }
}