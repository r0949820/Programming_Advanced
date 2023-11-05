namespace Onderneming_MVVM.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(WerknemerDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}