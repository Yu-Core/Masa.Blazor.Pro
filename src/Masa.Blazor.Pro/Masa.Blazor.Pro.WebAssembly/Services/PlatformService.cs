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
            string uri = $"_content/Masa.Blazor.Pro.Rcl/{baseUri}";
            var result = await HttpClient.GetFromJsonAsync<T>(uri);
            return result ?? throw new Exception("not find json");
        }
    }
}
