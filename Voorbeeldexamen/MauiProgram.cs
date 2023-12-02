namespace Voorbeeldexamen;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// ViewModels
		builder.Services.AddSingleton<BaseViewModel> ();
		builder.Services.AddSingleton<FilmViewModel> ();
		builder.Services.AddSingleton<FilmDetailsViewModel> ();

		// Views
		builder.Services.AddSingleton<FilmView>();
		builder.Services.AddSingleton<VoegFilmToeView>();
		builder.Services.AddSingleton<FilmDetailView>();

		return builder.Build();

	}
}
