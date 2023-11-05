namespace Onderneming_MVVM.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

        [RelayCommand]
        async public Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

    }

}
