namespace Voorbeeldexamen.Views;

public partial class VoegFilmToeView : ContentPage
{
	public VoegFilmToeView(FilmViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}