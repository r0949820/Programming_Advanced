namespace Voorbereiding_ExamenJan.Views;

public partial class OptionsPage : ContentPage
{
    ViewModels.OptionsViewModel ViewModel;
    public OptionsPage(ViewModels.OptionsViewModel viewModel)
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