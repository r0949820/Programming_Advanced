namespace Onderneming_MVVM.ViewModels
{
    [QueryProperty(nameof(Werknemer), "Werknemer")]
    public partial class WerknemerDetailsViewModel : BaseViewModel
    {

        [ObservableProperty]
        Werknemer werknemer;
    }
}

