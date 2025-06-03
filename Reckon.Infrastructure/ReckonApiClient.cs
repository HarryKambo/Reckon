using Microsoft.Extensions.Logging;
using Reckon.Core.ModelDto;
using Reckon.Infrastructure.ResponseModel;
using System.Text;
using System.Text.Json;


namespace Reckon.Infrastructure
{
    public class ReckonApiClient
    {
        private readonly HttpClient _httpClient;
        private ILogger<ReckonApiClient> _logger;
     
        public ReckonApiClient(HttpClient client, ILogger<ReckonApiClient> logger) 
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri("https://join.reckon.com");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _logger = logger;
            
        }        

        public async Task<TextToSearch?> getTextToSearchAsync()
        {

            _logger.LogInformation("Information: Fetching search text from URI test2/textToSearch");
            var request = new HttpRequestMessage(HttpMethod.Get, "test2/textToSearch");
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            var Response = await _httpClient.SendAsync(request);            

            var content = await Response.Content.ReadAsStringAsync();
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            TextToSearch? textToSearch = JsonSerializer.Deserialize<TextToSearch>(content, options);
            return textToSearch;
           
        }

        public async Task<SubTextResponse?> getSubTextAsync()
        {
            _logger.LogInformation("Information: Fetching to be searched text from URI test2/subTexts");
            var request = new HttpRequestMessage(HttpMethod.Get, "test2/subTexts");
            request.Headers.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var Response = await _httpClient.SendAsync(request);          

            var content = await Response.Content.ReadAsStringAsync();
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            SubTextResponse? textToSearch = JsonSerializer.Deserialize<SubTextResponse>(content, options);
            return textToSearch;

        }

        public async Task<Task> postSearchResultAsync(ReckonPostRequestDTO data)
        {

            _logger.LogInformation("Information: Sending Post request to test2/submitResults");
            string jsonString = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");            

            var response = await _httpClient.PostAsync("test2/submitResults", content);            
            
            return Task.CompletedTask;

        }
    }
}
