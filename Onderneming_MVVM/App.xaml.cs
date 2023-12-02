namespace Onderneming_MVVM;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
    protected override void OnSleep()
    {
        MessagingCenter.Unsubscribe<InstellingViewModel>(this, "ThemeChanged");
    }
}
