namespace Voorbeeldexamen;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(FilmView), typeof(FilmView));
        Routing.RegisterRoute(nameof(VoegFilmToeView), typeof(VoegFilmToeView));
        Routing.RegisterRoute(nameof(FilmDetailView), typeof(FilmDetailView));
    }
}
