using ProefexamenJan.ViewModels;
using ProefexamenJan.Views;

namespace ProefexamenJan
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

            builder.Services.AddSingleton<BookViewModel>();
            builder.Services.AddSingleton<EmployeeViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<EmployeePage>();

            return builder.Build();
        }
    }
}