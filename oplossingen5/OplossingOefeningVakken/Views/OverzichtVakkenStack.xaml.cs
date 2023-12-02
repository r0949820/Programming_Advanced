using VakkenOefening.ViewModels;

namespace VakkenOefening.Views;

public partial class OverzichtVakkenStack : ContentPage
{
	public OverzichtVakkenStack(OverzichtVakkenViewModel viewModel)
	{
		InitializeComponent();

		viewModel.ToonVakken();

		BindingContext = viewModel;
		MfiToevoegen.BindingContext = viewModel;

		viewModel.Title = "Overzicht vakken stack";
	}
}