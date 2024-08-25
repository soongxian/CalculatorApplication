using CalculatorApplicationProcess.CalculationModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;

namespace CalculatorApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IndexModel> _logger;
        public Operation PlusResult { get; private set; }
        public Operation MultiplicationResult { get; private set; }

        public IndexModel(IHttpClientFactory httpClientFactory, ILogger<IndexModel> logger)
        {
            _httpClient = httpClientFactory.CreateClient("CalculatorClient");
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.PostAsync("/api/Calculation/Calculate", null); 
            response.EnsureSuccessStatusCode();

            var responseXml = await response.Content.ReadAsStringAsync();

            var serializer = new XmlSerializer(typeof(List<Operation>));
            using (var reader = new StringReader(responseXml))
            {
                var operations = (List<Operation>)serializer.Deserialize(reader);

                PlusResult = operations.FirstOrDefault(o => o.ID == "Plus");
                MultiplicationResult = operations.FirstOrDefault(o => o.ID == "Multiplication");

                _logger.LogInformation($"Plus Result: {PlusResult?.Result}");
                _logger.LogInformation($"Multiplication Result: {MultiplicationResult?.Result}");
            }
        }

    }
}
