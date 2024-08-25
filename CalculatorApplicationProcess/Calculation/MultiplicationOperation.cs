using CalculatorApplicationProcess.Calculation.Api;
using CalculatorApplicationProcess.CalculationBase;

namespace CalculatorApplicationProcess.Calculation
{
    public class MultiplicationOperation : BaseOperation
    {

        public override int Execute(List<int> values)
        {
            return AddOperation(values);
        }

        protected int AddOperation(List<int> values)
        {
            int result = 1;
            for (int i = 0; i < values.Count; i++)
            {
                result = result * values[i];
            }
            return result;
        }
    }
}
