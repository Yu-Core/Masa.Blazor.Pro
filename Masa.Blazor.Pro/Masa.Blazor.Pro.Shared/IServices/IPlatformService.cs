namespace Masa.Blazor.Pro.Shared
{
    public interface IPlatformService
    {
        Task<T> ReadJsonAsync<T>(string baseUri);
    }
}
