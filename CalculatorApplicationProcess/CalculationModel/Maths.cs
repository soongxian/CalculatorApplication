using System.Xml.Serialization;

namespace CalculatorApplicationProcess.CalculationModel
{
    [XmlRoot("Maths")]
    public class Maths
    {
        [XmlElement("Operation")]
        public List<Operation> Operations { get; set; }
    }
}
