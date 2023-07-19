using Masa.Blazor.Pro.Shared;
using System.Text.Json;

namespace Masa.Blazor.Pro.Photino.Services
{
    public class PlatformService : IPlatformService
    {
        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"wwwroot/{baseUri}";
            if (!File.Exists(uri))
            {
                uri = $"wwwroot/_content/Masa.Blazor.Pro.Rcl/{baseUri}";
            }

            var json = await File.ReadAllTextAsync(uri);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(json, options) ?? throw new("not find json");
        }
    }
}
