using Microsoft.Extensions.Logging;
using Voorbereiding_ExamenJan.ViewModels;
using Voorbereiding_ExamenJan.Views;

namespace Voorbereiding_ExamenJan
{
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<OptionsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<OptionsPage>();

            return builder.Build();
        }
    }
}