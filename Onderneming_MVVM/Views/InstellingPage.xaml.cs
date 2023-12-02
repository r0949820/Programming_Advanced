namespace Onderneming_MVVM.Views;

public partial class InstellingPage : ContentPage
{
    InstellingViewModel vm = new InstellingViewModel();

    public InstellingPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OnToggled(Object sender, ToggledEventArgs args)
    {
        if (!vm.GetoggledDoorLaden)
        {
            vm.ToggleTheme();
        }
        vm.GetoggledDoorLaden = false;
    }
}