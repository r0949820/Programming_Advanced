namespace Onderneming_MVVM.Views;

public partial class WeerPage : ContentPage
{
    public WeerPage()
    {
        InitializeComponent();
        BindingContext = new ApiViewModel();
    }
}