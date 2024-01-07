﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VoorbeeldOrders.Data.Repository;
using VoorbeeldOrders.Models;

namespace VoorbeeldOrders.ViewModels
{
    public partial class WerknemersViewModel : BaseViewModel
    {
        private IWerknemerRepository _werknemerRepository;

        [ObservableProperty]
        private ObservableCollection<Werknemer> werknemers;

        [ObservableProperty]
        private string functie;

        [ObservableProperty]
        private string achternaam = "";

        [ObservableProperty]
        private string voornaam = "";

        [ObservableProperty]
        private string id;

        public WerknemersViewModel()
        {
            _werknemerRepository = new WerknemerRepository();
        }

        [RelayCommand]
        public void AlleWerknemersOphalen()
        {
            IsBusy = true;
            Werknemers = new ObservableCollection<Werknemer>(_werknemerRepository.OphalenWerknemers());
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemersZoekenViaFunctie()
        {
            Werknemers = new ObservableCollection<Werknemer>(_werknemerRepository.OphalenWerknemersViaFunctie(Functie));
        }

        [RelayCommand]
        public void WerknemersZoekenViaNaam()
        {
            Werknemers = new ObservableCollection<Werknemer>(_werknemerRepository.OphalenWerknemersViaAchternaamEnVoornaam(Achternaam, Voornaam));
        }

        [RelayCommand]
        public void WerknemersZoekenViaId()
        {
            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldige ID.", "Sluiten");
                return;
            }
            var werknemer = _werknemerRepository.OphalenWerknemerViaPK(id);
            if (werknemer == null)
                Shell.Current.DisplayAlert("Fout", $"Werknemer met ID {id} werd niet gevonden.", "Sluiten");
            else
                Shell.Current.DisplayAlert("Werknemer gevonden", werknemer.VolledigeNaam, "Sluiten");
        }
    }
}