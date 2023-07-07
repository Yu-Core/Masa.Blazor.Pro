using Masa.Blazor.Pro.Shared;
using System.Net.Http.Json;

namespace Masa.Blazor.Pro.WebAssembly.Services
{
    public class PlatformService : IPlatformService
    {
        private HttpClient HttpClient { get; set; }

        public PlatformService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            var result = await HttpClient.GetFromJsonAsync<T>($"_content/Masa.Blazor.Pro.Rcl/{baseUri}");
            return result ?? throw new Exception("not find weather.json");
        }
    }
}
