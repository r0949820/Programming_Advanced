using ProefexamenJan.ViewModels;

namespace ProefexamenJan.Views;

public partial class MainPage : ContentPage
{
    public MainPage(BookViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}