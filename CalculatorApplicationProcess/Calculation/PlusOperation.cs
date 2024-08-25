using CalculatorApplicationProcess.Calculation.Api;
using CalculatorApplicationProcess.CalculationBase;

namespace CalculatorApplicationProcess.Calculation
{
    public class PlusOperation : BaseOperation
    {

        public override int Execute(List<int> values)
        {
            return MultiplicationOperation(values);
        }

        protected int MultiplicationOperation(List<int> values)
        {
            int result = 0;
            for (int i = 0; i < values.Count; i++)
            {
                result = result + values[i];
            }
            return result;
        }
    }
}
