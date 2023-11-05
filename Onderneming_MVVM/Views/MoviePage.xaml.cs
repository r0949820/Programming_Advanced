namespace Onderneming_MVVM.Views;

public partial class MoviePage : ContentPage
{
    public MoviePage()
    {
        InitializeComponent();
        BindingContext = new ApiViewModel();
    }
}