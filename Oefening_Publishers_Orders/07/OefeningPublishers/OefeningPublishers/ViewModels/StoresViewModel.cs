using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OefeningPublishers.Data.Repository;
using OefeningPublishers.Models;
using System.Collections.ObjectModel;

namespace OefeningPublishers.ViewModels
{
    public partial class StoresViewModel : BaseViewModel
    {
        private IStore _storeRepo;

        [ObservableProperty]
        private ObservableCollection<Store> stores;

        [ObservableProperty]
        private string staat;

        [ObservableProperty]
        private string naam;

        [ObservableProperty]
        private string id;

        public StoresViewModel()
        {
            _storeRepo = new StoreRepository();
        }
        [RelayCommand]
        public void StoresZoekenViaNaam()
        {
            if (Naam == null)
            {
                Naam = "";
            }

            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepo.OphalenStoresViaNaam(Naam));
            IsBusy = false;
        }

        [RelayCommand]
        public void StoresZoekenViaStaat()
        {
            if (Staat == null)
            {
                Staat = "";
            }
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepo.OphalenStoresViaStaat(Staat));
            IsBusy = false;
        }

        [RelayCommand]
        public void StoresZoekenViaNaamEnStaat()
        {
            if (Naam == null & Staat == null)
            {
                Naam = "";
                Staat = "";
            }
            IsBusy = true;
            Stores = new ObservableCollection<Store>(_storeRepo.OphalenStoresViaNaamEnStaat(Naam, Staat));
            IsBusy = false;
        }

        [RelayCommand]
        public void StoresZoekenViaId()
        {
            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldige ID.", "Sluiten");
                return;
            }
            var store = _storeRepo.OphalenStoreViaId(id);
            if (store == null)
                Shell.Current.DisplayAlert("Fout", $"Store met ID {id} werd niet gevonden.", "Sluiten");
            else
                Shell.Current.DisplayAlert("Store gevonden", store.Name, "Sluiten");
        }
    }
}