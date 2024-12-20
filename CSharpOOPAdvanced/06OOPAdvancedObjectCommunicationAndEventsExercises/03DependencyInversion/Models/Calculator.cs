﻿public class Calculator : ICalculator
{
    private ICalculationStrategy calculationStrategy;

    public Calculator(ICalculationStrategy calculationStrategy)
    {
        this.ChangeStrategy(calculationStrategy);
    }

    public void ChangeStrategy(ICalculationStrategy calculationStrategy)
    {
        this.calculationStrategy = calculationStrategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.calculationStrategy.Calculate(firstOperand, secondOperand);
    }
}
