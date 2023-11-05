using VakkenOefening.ViewModels;

namespace VakkenOefening.Views;

public partial class OverzichtVakkenFlex : ContentPage
{
	public OverzichtVakkenFlex(OverzichtVakkenViewModel viewModel)
	{
		InitializeComponent();

		viewModel.ToonVakken();

		BindingContext = viewModel;
		MfiToevoegen.BindingContext = viewModel;

		viewModel.Title = "Overzicht vakken flex";
	}
}