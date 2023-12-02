using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakkenOefening.ViewModels
{
    public partial class OptionsViewModel : BaseViewModel
    {
		[ObservableProperty]
		bool isToggled;

		public bool GetoggledDoorLaden = false;

		public OptionsViewModel() 
		{
			Title = "Instellingen";
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
