using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // MainPage'i kök sayfa olarak ayarla
            return new Window(new MainPage());
        }
    }
}
