using Masa.Blazor.Pro.Shared;
using System.Text.Json;

namespace Masa.Blazor.Pro.Maui.Services
{
    public class PlatformService : IPlatformService
    {
        public async Task<T> ReadJsonAsync<T>(string baseUri)
        {
            string uri = $"wwwroot/_content/Masa.Blazor.Pro.Rcl/{baseUri}";
            bool exists = await FileSystem.AppPackageFileExistsAsync(uri);
            if (!exists)
            {
                throw new Exception("not find json");
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync(uri).ConfigureAwait(false);
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync().ConfigureAwait(false);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(contents, options) ?? throw new("not find json");
        }
    }
}
