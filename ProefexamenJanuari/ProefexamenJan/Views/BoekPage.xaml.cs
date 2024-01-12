using ProefexamenJan.ViewModels;
namespace ProefexamenJan.Views;

public partial class BoekPage : ContentPage
{
    public BoekPage(BookViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}