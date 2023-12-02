namespace VakkenOefening.Views;

public partial class Options : ContentPage
{
	ViewModels.OptionsViewModel ViewModel;

	public Options(ViewModels.OptionsViewModel viewModel)
	{
		InitializeComponent();

		ViewModel = viewModel;
		BindingContext = viewModel;
	}

	private void OnToggled(Object sender, ToggledEventArgs args)
	{
		if (!ViewModel.GetoggledDoorLaden)
		{
			ViewModel.ToggleTheme();
		}

		ViewModel.GetoggledDoorLaden = false;
	}
}