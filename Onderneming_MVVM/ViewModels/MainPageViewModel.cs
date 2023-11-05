namespace Onderneming_MVVM.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        WerknemerRepository _repo;

        [ObservableProperty]
        private ObservableCollection<Werknemer> werknemers;

        [ObservableProperty]
        private Werknemer werknemer;

        public MainPageViewModel(WerknemerRepository Repo)
        {
            Title = "Werknemers";
            _repo = Repo;
            werknemer = new Werknemer();
            ToonWerknemers();
        }

        [RelayCommand]
        public void GoToToevoegen()
        {
            Shell.Current.GoToAsync(nameof(ToevoegenPage), true);
        }

        [RelayCommand]
        public async Task VoegWerknemerToe()
        {
            if (Werknemer == null)
                return;
            Werknemers.Add(Werknemer);
            await GoBackAsync();
        }

        [RelayCommand]
        async Task GoToDetails(Werknemer werknemer)
        {
            if (werknemer == null)
                return;
            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Werknemer", werknemer }
        });
        }

        [RelayCommand]
        public void ToonWerknemers()
        {
            Werknemers = new ObservableCollection<Werknemer>(_repo.GetWerknemers());
        }

        [RelayCommand]
        public void VerwijderWerknemer(Werknemer werknemer)
        {
            if (werknemer == null)
                return;
            werknemers.Remove(werknemer);
        }
    }

}
