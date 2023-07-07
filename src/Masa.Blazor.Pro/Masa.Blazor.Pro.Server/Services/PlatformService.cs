using Masa.Blazor.Pro.Shared;
using System.Text.Json;

namespace Masa.Blazor.Pro.Server.Services
{
    public class PlatformService : IPlatformService
    {
        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            using var reader = new StreamReader($"{AppContext.BaseDirectory}/wwwroot/{baseUri}");
            var contents = await reader.ReadToEndAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(contents, options) ?? throw new("not find weather.json");
        }
    }
}
