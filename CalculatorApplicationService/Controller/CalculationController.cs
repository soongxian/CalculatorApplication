using CalculatorApplicationProcess.Calculation.Api;
using CalculatorApplicationProcess.CalculationFactories;
using CalculatorApplicationProcess.CalculationModel;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace CalculatorApplicationService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly string filePath = Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory()).ToString(),
            "calculation.xml"
            );

        [HttpPost("Calculate")]
        public async Task<IActionResult> Calculate()
        {
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("The XML file was not found.");
            }
            var xmlContent = await System.IO.File.ReadAllTextAsync(filePath);

            var serializer = new XmlSerializer(typeof(Maths));
            using (var reader = new StringReader(xmlContent))
            {
                var maths = (Maths)serializer.Deserialize(reader);

                var results = maths.Operations.Select(operation =>
                {
                    IOperation op = OperationFactory.CreateOperation(operation.ID);
                    var result = op.Execute(operation.Values);
                    operation.Result = result;
                    return operation;
                }).ToList();

                var resultSerializer = new XmlSerializer(typeof(List<Operation>));
                using (var resultWriter = new StringWriter())
                {
                    resultSerializer.Serialize(resultWriter, results);
                    return Content(resultWriter.ToString(), "application/xml");
                }
            }
        }
    }
}
