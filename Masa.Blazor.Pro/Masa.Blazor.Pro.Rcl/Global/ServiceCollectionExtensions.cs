using Masa.Blazor.Pro.Shared;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGlobal(this IServiceCollection services)
        {
            return services.AddGlobalAsync().Result;
        }
        public static async Task<IServiceCollection> AddGlobalAsync(this IServiceCollection services)
        {
            var platformService = services.BuildServiceProvider().GetRequiredService<IPlatformService>();
            var list = await platformService.ReadJsonAsync<List<NavModel>>("nav/nav.json").ConfigureAwait(false);
            services.AddNav(list);
            services.AddScoped<GlobalConfig>();

            return services;
        }
    }
}
