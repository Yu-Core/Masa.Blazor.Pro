namespace Masa.Blazor.Pro.Maui
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}