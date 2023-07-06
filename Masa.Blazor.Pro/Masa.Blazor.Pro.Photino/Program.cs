using Masa.Blazor.Pro.Photino.Services;
using Masa.Blazor.Pro.Rcl;
using Masa.Blazor.Pro.Shared;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.RootComponents.Add<App>("#app");
        appBuilder.Services.AddMasaBlazor(builder =>
        {
            builder.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4318FF";
                theme.Themes.Light.Accent = "#4318FF";
            });
        }).AddI18nForServer("wwwroot/i18n");

        appBuilder.Services.AddScoped<IPlatformService, PlatformService>();
        appBuilder.Services.AddGlobal();

        var app = appBuilder.Build();

        app.MainWindow
            .SetTitle("Photino Blazor Sample");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
        };

        app.Run();
    }
}