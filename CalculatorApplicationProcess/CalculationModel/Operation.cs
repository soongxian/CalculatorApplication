using System.Xml.Serialization;

namespace CalculatorApplicationProcess.CalculationModel
{
    public class Operation
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlElement("Value")]
        public List<int> Values { get; set; }

        [XmlElement("Result")]
        public int Result { get; set; }
    }
}
