using VakkenOefening.ViewModels;

namespace VakkenOefening.Views;

public partial class DetailsVak : ContentPage
{
	public DetailsVak(VakViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
		MfiOpslaan.BindingContext = viewModel;

		Loaded += DetailsVak_Loaded;
	}

	private void DetailsVak_Loaded(object sender, EventArgs e)
	{
		(BindingContext as VakViewModel).ToonVak();
	}
}