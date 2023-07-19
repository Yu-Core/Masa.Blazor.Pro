using Masa.Blazor.Pro.Shared;
using System.Text.Json;

namespace Masa.Blazor.Pro.Server.Services
{
    public class PlatformService : IPlatformService
    {
        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
#if DEBUG
            var uri = $"{AppContext.BaseDirectory}/wwwroot/{baseUri}";
#else
            var uri = $"{AppContext.BaseDirectory}/wwwroot/_content/YourWeather.Rcl/{baseUri}";
#endif
            if (!File.Exists(uri))
            {
                throw new Exception("not find json");
            }

            using var reader = new StreamReader(uri);
            var contents = await reader.ReadToEndAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(contents, options) ?? throw new("not find json");
        }
    }
}
