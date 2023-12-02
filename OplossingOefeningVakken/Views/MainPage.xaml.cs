namespace VakkenOefening.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OverzichtVakkenStack_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OverzichtVakkenStack(new(new())));
	}

	private void OverzichtVakkenGrid_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OverzichtVakkenGrid(new(new())));
	}

	private void OverzichtVakkenFlex_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new OverzichtVakkenFlex(new(new())));
	}
}

