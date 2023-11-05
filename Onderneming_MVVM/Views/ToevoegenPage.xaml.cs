namespace Onderneming_MVVM.Views;

public partial class ToevoegenPage : ContentPage
{
    public ToevoegenPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}