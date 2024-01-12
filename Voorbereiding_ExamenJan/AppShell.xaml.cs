using Voorbereiding_ExamenJan.Views;

namespace Voorbereiding_ExamenJan
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(OptionsPage), typeof(OptionsPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}