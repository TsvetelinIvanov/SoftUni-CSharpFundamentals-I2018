public interface ICalculator
{
    int PerformCalculation(int firstOperand, int secondOperand);

    void ChangeStrategy(ICalculationStrategy calculationStrategy);
}