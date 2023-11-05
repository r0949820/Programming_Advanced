namespace VakkenOefening.Views;

public partial class MovieView : ContentPage
{
    public MovieView()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MovieViewModel();
    }
    //Titel search
    private async void SearchField_TextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = BindingContext as ViewModels.MovieViewModel;

        if (viewModel == null)
        {
            return;
        }

        if (viewModel.SearchValue.Length < 3)
        {
            return;
        }

        await viewModel.ToonFilms();
    }

    //Year search
    private async void YearField_TextChanged(object sender, TextChangedEventArgs e)
    {
        var vm = BindingContext as ViewModels.MovieViewModel;

        if (vm == null)
        {
            return;
        }

        // Trimmen want op smartphones kunnen extra spaties komen:
        string jaartal = vm.YearValue.Trim();

        if (int.TryParse(jaartal, out _) && jaartal.Length == 4)
        {
            await vm.ToonFilms();
        }
        else
        {
            return;
        }
    }
}