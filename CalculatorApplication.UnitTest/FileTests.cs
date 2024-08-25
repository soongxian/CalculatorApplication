
using System.Xml.Linq;

namespace CalculatorApplication.UnitTest
{
    [TestFixture]
    public class FileTests
    {
        private readonly string _filePath;

        public FileTests()
        {
            _filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "calculation.xml");
        }

        [Test]
        public void FileExistence_Check()
        {
            try
            {
                bool fileExists = File.Exists(_filePath);
                Console.WriteLine($"File exists: {fileExists}");
                Assert.True(fileExists, "The connection.xml file was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                Assert.True(false, "Test aborted due to exception.");
            }
        }

        [Test]
        public void FileStructure_Check()
        {
            Assert.IsTrue(File.Exists(_filePath), "The calculation.xml file was not found.");

            try
            {
                var xmlContent = XDocument.Load(_filePath);

                var root = xmlContent.Root;
                Assert.IsNotNull(root, "The XML does not have a root element.");
                Assert.AreEqual("Maths", root.Name.LocalName, "The root element is not 'Maths'.");

                var operations = root.Elements("Operation");
                Assert.AreEqual(2, operations.Count(), "The XML does not contain exactly two 'Operation' elements.");

                var firstOperation = operations.First();
                Assert.AreEqual("Plus", firstOperation.Attribute("ID")?.Value, "The first 'Operation' ID is not 'Plus'.");
                Assert.AreEqual(new[] { "2", "3" },
                                firstOperation.Elements("Value").Select(v => v.Value).ToArray(),
                                "The values of the first 'Operation' are not as expected.");

                var secondOperation = operations.Last();
                Assert.AreEqual("Multiplication", secondOperation.Attribute("ID")?.Value, "The second 'Operation' ID is not 'Multiplication'.");
                Assert.AreEqual(new[] { "4", "5" },
                                secondOperation.Elements("Value").Select(v => v.Value).ToArray(),
                                "The values of the second 'Operation' are not as expected.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed with exception: {ex.Message}");
            }
        }
    }
}
