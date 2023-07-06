using Masa.Blazor.Pro.Shared;
using Masa.Blazor.Pro.Wpf.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Masa.Blazor.Pro.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddMasaBlazor(builder =>
            {
                builder.ConfigureTheme(theme =>
                {
                    theme.Themes.Light.Primary = "#4318FF";
                    theme.Themes.Light.Accent = "#4318FF";
                });
            }).AddI18nForServer("wwwroot/i18n");
            serviceCollection.AddSingleton<IPlatformService, PlatformService>();
            serviceCollection.AddGlobal();
#if DEBUG
            serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}