using ExamenNovember.ViewModels;
using ExamenNovember.Views;

namespace ExamenNovember;

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

        builder.Services.AddTransient<MovieViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<PersonagesPage>();

        return builder.Build();
    }
}
