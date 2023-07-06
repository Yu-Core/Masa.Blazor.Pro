using Masa.Blazor.Pro.Maui.Extend;
using Masa.Blazor.Pro.Maui.Services;
using Masa.Blazor.Pro.Shared;

namespace Masa.Blazor.Pro.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddMasaBlazor(builder =>
            {
                builder.ConfigureTheme(theme =>
                {
                    theme.Themes.Light.Primary = "#4318FF";
                    theme.Themes.Light.Accent = "#4318FF";
                });
            }).AddI18nForMauiBlazor("wwwroot/_content/Masa.Blazor.Pro.Rcl/i18n");

            builder.Services.AddScoped<IPlatformService, PlatformService>();
            builder.Services.AddGlobal();

            return builder.Build();
        }
    }
}