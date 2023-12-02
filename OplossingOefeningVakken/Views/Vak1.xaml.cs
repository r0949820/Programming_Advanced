using VakkenOefening.ViewModels;

namespace VakkenOefening.Views;

public partial class Vak1 : ContentPage
{
	public Vak1(VakViewModel vm, int idVak)
	{
		InitializeComponent();

		vm.ToonVak(idVak);

		BindingContext = vm;
	}

	private async void BtnOpslaan_Clicked(object sender, EventArgs e)
	{
		VakViewModel vm = BindingContext as VakViewModel;

		string infoString = string.Empty;

		infoString += "Vast lokaal: " + vm.Vak.HeeftVastLokaal.ToString();
		infoString += ", Lokaalnummer: " + vm.Vak.VastLokaalBlok + vm.Vak.VastLokaalNummer;
		infoString += ", Datum eerste les: " + vm.Vak.DatumEersteLes.ToShortDateString();
		infoString += ", Score: " + vm.Vak.VerwachteScore + "/20";

		await DisplayAlert("Info", infoString, "Terug aub");
	}
}