using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakkenOefening.Data;
using VakkenOefening.Models;
using VakkenOefening.Views;

namespace VakkenOefening.ViewModels
{
	public partial class OverzichtVakkenViewModel : BaseViewModel
	{
		VakRepository _repo;

		[ObservableProperty]
		private ObservableCollection<Vak> vakken;

		public OverzichtVakkenViewModel(VakRepository Repo)
		{
			_repo = Repo;
		}

		[RelayCommand]
		public void ToonVakken()
		{
			Vakken = new ObservableCollection<Vak>(_repo.GetVakken(false));
		}

		[RelayCommand]
		public async Task OpenDetailsVak(Vak vak)
		{
			if (vak == null)
				return;

			await Shell.Current.GoToAsync(nameof(DetailsVak), true, new Dictionary<string, object>
			{
				{"Vak", vak }
			});
		}

		[RelayCommand]
		public void DeleteVak(Vak vak)
		{
			if (vak == null)
				return;

			Vakken.Remove(vak);
		}

		[RelayCommand]
		public async Task VoegVakToe()
		{
			Vak vakNieuw = new Vak();
			Vak vakLaatste = vakken.Last();

			if (vakLaatste == null)
			{
				// Geen vak gevonden: alles op laagste zetten
				vakNieuw.Id = 1;
				vakNieuw.RowNumberGrid = 0;
				vakNieuw.ColumnNumberGrid = 0;
			} 
			else 
			{
				// Wel vak gevonden: ID is eentje hoger:
				vakNieuw.Id = vakLaatste.Id + 1;

				if (vakLaatste.ColumnNumberGrid == 0)
				{
					// Indien het laatste vak in de eerste kolom (index 0) staat:
					// zelfde rij nemen en kolom 2 (index 1)

					vakNieuw.ColumnNumberGrid = 1;
					vakNieuw.RowNumberGrid = vakLaatste.RowNumberGrid;
				} 
				else
				{
					// Indien het laatste vak in de tweede kolom staat:
					// volgende rij nemen en kolom 1 (index 0)
					vakNieuw.ColumnNumberGrid = 0;
					vakNieuw.RowNumberGrid = vakLaatste.RowNumberGrid + 1;
				}
			}

			vakken.Add(vakNieuw);

			await OpenDetailsVak(vakNieuw);
		}
	}
}
