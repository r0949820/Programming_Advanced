using ExamenNovember.Views;

namespace ExamenNovember;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PersonagesPage), typeof(PersonagesPage));
    }
}
