using System.Net.Http;
using System.Threading.Tasks;

namespace ElGuerre.PowerBI.PerformanceCounters.Providers
{
    public class RestProvider
    {
        private readonly HttpClient _httpClient;

        public RestProvider()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<HttpResponseMessage> PublishToPoweBIAsync(string url, string data)
        {
            // Add brackets for Power BI
            return await PostAsync(url, $"[{data}]");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string data)
        {            
            HttpContent content = new StringContent(data);

            // content.Headers.Add();

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
