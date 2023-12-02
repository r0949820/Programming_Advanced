using ExamenNovember.ViewModels;

namespace ExamenNovember.Views;

public partial class PersonagesPage : ContentPage
{
    public PersonagesPage(MovieViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        Loaded += PersonagesPage_Loaded;
    }

    private void PersonagesPage_Loaded(object sender, EventArgs e)
    {
        (BindingContext as MovieViewModel).ToonPersonages();
    }
}