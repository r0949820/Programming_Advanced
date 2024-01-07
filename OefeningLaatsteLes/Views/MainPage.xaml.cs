using OefeningLaatsteLes.ViewModels;

namespace OefeningLaatsteLes.Views;

public partial class MainPage : ContentPage
{
    public MainPage(SaleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}