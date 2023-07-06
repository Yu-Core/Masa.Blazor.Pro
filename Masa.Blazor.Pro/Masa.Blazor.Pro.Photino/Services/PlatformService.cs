using Masa.Blazor.Pro.Shared;
using System.Text.Json;

namespace Masa.Blazor.Pro.Photino.Services
{
    public class PlatformService : IPlatformService
    {
        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string path = $"wwwroot/{baseUri}";
            if (!File.Exists(path))
            {
                path = $"wwwroot/_content/Masa.Blazor.Pro.Rcl/{baseUri}";
            }

            var json = await File.ReadAllTextAsync(path);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(json, options) ?? throw new("not find weather.json");
        }
    }
}
