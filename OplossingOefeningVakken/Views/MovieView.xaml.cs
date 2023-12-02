namespace VakkenOefening.Views;

public partial class MovieView : ContentPage
{
	public MovieView()
	{
		InitializeComponent();
		BindingContext = new ViewModels.MovieViewModel();
	}

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

	private async void YearField_TextChanged(object sender, TextChangedEventArgs e)
	{
		var viewModel = BindingContext as ViewModels.MovieViewModel;

		if (viewModel == null)
		{
			return;
		}

		// Trimmen want op smartphones kunnen extra spaties komen:
		string jaartal = viewModel.YearValue.Trim();

		if (int.TryParse(jaartal, out _) && jaartal.Length == 4)
		{
			await viewModel.ToonFilms();
		}
		else
		{
			return;
		}
	}
}