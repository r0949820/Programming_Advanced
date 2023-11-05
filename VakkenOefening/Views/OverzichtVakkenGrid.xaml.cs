using VakkenOefening.ViewModels;

namespace VakkenOefening.Views;

public partial class OverzichtVakkenGrid : ContentPage
{
	public OverzichtVakkenGrid(OverzichtVakkenViewModel viewModel)
	{
		InitializeComponent();

		viewModel.ToonVakken();

		BindingContext = viewModel;
		MfiToevoegen.BindingContext = viewModel;

		viewModel.Title = "Overzicht vakken grid";
	}
}