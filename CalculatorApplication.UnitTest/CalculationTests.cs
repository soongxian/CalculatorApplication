using CalculatorApplicationProcess.Calculation.Api;
using CalculatorApplicationProcess.CalculationFactories;
using CalculatorApplicationProcess.CalculationModel;
using CalculatorApplicationService.Controller;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalculatorApplication.UnitTest
{

    [TestFixture]
    public class CalculationTests
    {
        private string _filePath;
        private CalculationController _controller;
        private Mock<IOperation> _mockPlusOperation;
        private Mock<IOperation> _mockMultiplicationOperation;

        [SetUp]
        public void Setup()
        {
            _controller = new CalculationController();
            _filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "calculation.xml");
            if (!File.Exists(_filePath))
            {
                Assert.Fail("The XML file 'calculation.xml' does not exist.");
            }
        }

        [Test]
        public async Task Calculate_WithXmlContent_CorrectResult()
        {
            var expectedResults = new List<Operation>
        {
            new Operation { ID = "Plus", Values = new List<int> { 2, 3 }, Result = 5 },
            new Operation { ID = "Multiplication", Values = new List<int> { 4, 5 }, Result = 20 }
        };
            var result = await _controller.Calculate() as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("application/xml", result.ContentType);

            var serializer = new XmlSerializer(typeof(List<Operation>));
            using (var reader = new StringReader(result.Content))
            {
                var actualResults = (List<Operation>)serializer.Deserialize(reader);

                Assert.AreEqual(expectedResults.Count, actualResults.Count, "Operation count mismatch.");

                for (int i = 0; i < expectedResults.Count; i++)
                {
                    Assert.AreEqual(expectedResults[i].ID, actualResults[i].ID);
                    Assert.AreEqual(expectedResults[i].Values, actualResults[i].Values);
                    Assert.AreEqual(expectedResults[i].Result, actualResults[i].Result);
                }
            }
        }
    }
}
