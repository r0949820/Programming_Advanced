using OplossingPublishers.ViewModels;

namespace OplossingPublishers.Views;

public partial class StoresPage : ContentPage
{
    public StoresPage(StoresViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}