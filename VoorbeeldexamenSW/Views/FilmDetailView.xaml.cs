namespace Voorbeeldexamen.Views;

public partial class FilmDetailView : ContentPage
{
	public FilmDetailView(FilmDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        Loaded += FilmDetailView_Loaded;
	}

    private async void FilmDetailView_Loaded(object sender, EventArgs e)
    {
        var viewModel = BindingContext as FilmDetailsViewModel;
        await viewModel.LoadPeople();
    }
}