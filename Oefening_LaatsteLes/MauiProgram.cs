using OefeningLaatsteLes.ViewModels;
using OefeningLaatsteLes.Views;

namespace OefeningLaatsteLes
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


            builder.Services.AddSingleton<SaleViewModel>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}