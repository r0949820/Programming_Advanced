using VakkenOefening.Views;
using VakkenOefening.Data;
using VakkenOefening.ViewModels;

namespace VakkenOefening;

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

				fonts.AddFont("TMCandor-Bold.otf", "TitleFont");
				fonts.AddFont("TMCandor-Light.otf", "DetailFont");
			});

		builder.Services.AddTransient<VakViewModel>();
		builder.Services.AddSingleton<OverzichtVakkenViewModel>();
		builder.Services.AddSingleton<OptionsViewModel>();

		builder.Services.AddSingleton<VakRepository>();
		builder.Services.AddSingleton<DocentRepository>();

		builder.Services.AddSingleton<OverzichtVakkenFlex>();
		builder.Services.AddSingleton<OverzichtVakkenGrid>();
		builder.Services.AddSingleton<OverzichtVakkenStack>();

		builder.Services.AddSingleton<Vak1>();
		builder.Services.AddSingleton<Vak2>();
		builder.Services.AddSingleton<Vak3>();
		builder.Services.AddSingleton<Vak4>();
		builder.Services.AddSingleton<Vak5>();
		builder.Services.AddTransient<DetailsVak>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<Options>();

		return builder.Build();
	}
}
