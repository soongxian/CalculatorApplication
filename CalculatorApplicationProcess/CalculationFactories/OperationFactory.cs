using CalculatorApplicationProcess.Calculation.Api;
using CalculatorApplicationProcess.Calculation;

namespace CalculatorApplicationProcess.CalculationFactories
{
    public static class OperationFactory
    {
        public static IOperation CreateOperation(string id)
        {
            switch (id)
            {
                case "Plus":
                    return new PlusOperation();
                case "Multiplication":
                    return new MultiplicationOperation();
                default:
                    throw new NotSupportedException($"Operation '{id}' is not supported.");
            }
        }
    }
}
