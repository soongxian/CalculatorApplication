using CalculatorApplicationProcess.Calculation.Api;

namespace CalculatorApplicationProcess.CalculationBase
{
    public abstract class BaseOperation : IOperation
    {
        public abstract int Execute(List<int> values);
    }
}
