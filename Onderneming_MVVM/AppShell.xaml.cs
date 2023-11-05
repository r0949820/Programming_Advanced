namespace Onderneming_MVVM;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(ToevoegenPage), typeof(ToevoegenPage));
        Routing.RegisterRoute(nameof(MoviePage), typeof(MoviePage));
        Routing.RegisterRoute(nameof(WeerPage), typeof(WeerPage));
    }
}
