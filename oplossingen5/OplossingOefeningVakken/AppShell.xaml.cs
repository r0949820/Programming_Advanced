using VakkenOefening.Views;

namespace VakkenOefening;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsVak), typeof(DetailsVak));

		Routing.RegisterRoute(nameof(OverzichtVakkenFlex), typeof(OverzichtVakkenFlex));
		Routing.RegisterRoute(nameof(OverzichtVakkenGrid), typeof(OverzichtVakkenGrid));
		Routing.RegisterRoute(nameof(OverzichtVakkenStack), typeof(OverzichtVakkenStack));

		Routing.RegisterRoute("//Views/" + nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(Options), typeof(Options));
	}

	private async void MfiGrid_Clicked(object sender, EventArgs e)
	{
		await Current.GoToAsync(nameof(OverzichtVakkenGrid), true);
	}

	private async void MfiFlex_Clicked(object sender, EventArgs e)
	{
		await Current.GoToAsync(nameof(OverzichtVakkenFlex), true);
	}

	private async void MfiStack_Clicked(object sender, EventArgs e)
	{
		await Current.GoToAsync(nameof(OverzichtVakkenStack), true);
	}

	private async void MfiHome_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Views/" + nameof(MainPage), true);
	}

	private async void MfiOptions_Clicked(object sender, EventArgs e)
	{
		await Current.GoToAsync(nameof(Options), true);
	}
}
