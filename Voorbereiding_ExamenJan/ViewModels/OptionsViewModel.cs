using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Voorbereiding_ExamenJan.ViewModels
{
    public partial class OptionsViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isToggled;

        public bool GetoggledDoorLaden = false;

        public OptionsViewModel()
        {
            var Theme = Preferences.Get("Theme", "");

            if (!IsToggled)
            {
                if (Theme == "Dark")
                {
                    GetoggledDoorLaden = true;
                    IsToggled = true;
                }
            }
        }

        [RelayCommand]
        public void ToggleTheme()
        {
            var CurrentTheme = Application.Current.RequestedTheme;

            Application.Current.UserAppTheme = CurrentTheme.ToString() == "Light" ? AppTheme.Dark : AppTheme.Light;

            Preferences.Set("Theme", Application.Current.UserAppTheme.ToString());

            MessagingCenter.Send(this, "ThemeChanged");
        }
    }
}
