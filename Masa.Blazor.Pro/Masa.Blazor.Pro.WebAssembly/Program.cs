using Masa.Blazor.Pro.Rcl;
using Masa.Blazor.Pro.Shared;
using Masa.Blazor.Pro.WebAssembly.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Services
             .AddMasaBlazor(builder =>
             {
                 builder.ConfigureTheme(theme =>
                 {
                     theme.Themes.Light.Primary = "#4318FF";
                     theme.Themes.Light.Accent = "#4318FF";
                 });
             })
             .AddI18nForWasmAsync(Path.Combine(builder.HostEnvironment.BaseAddress, "_content/Masa.Blazor.Pro.Rcl/i18n"));
builder.Services.AddScoped<IPlatformService, PlatformService>();
await builder.Services.AddGlobalAsync();

await builder.Build().RunAsync();
