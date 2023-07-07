using Masa.Blazor.Pro.Rcl;
using Masa.Blazor.Pro.Shared;
using Masa.Blazor.Pro.Winforms.Services;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace Masa.Blazor.Pro.Winforms
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            services.AddMasaBlazor(builder =>
            {
                builder.ConfigureTheme(theme =>
                {
                    theme.Themes.Light.Primary = "#4318FF";
                    theme.Themes.Light.Accent = "#4318FF";
                });
            }).AddI18nForServer("wwwroot/i18n");

            services.AddScoped<IPlatformService, PlatformService>();
            services.AddGlobal();
#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif

            blazorWebView1.HostPage = "wwwroot/index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}