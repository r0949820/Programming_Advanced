namespace Voorbeeldexamen.Views;

public partial class FilmView : ContentPage
{
	public FilmView(FilmViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}