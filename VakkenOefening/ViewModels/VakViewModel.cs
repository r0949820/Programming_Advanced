using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakkenOefening.Data;
using VakkenOefening.Models;

namespace VakkenOefening.ViewModels
{
	[QueryProperty(nameof(Vak), "Vak")]
    public partial class VakViewModel : BaseViewModel
	{
		VakRepository _repo;

		[ObservableProperty]
		private Vak vak;

		public VakViewModel(VakRepository Repo)
		{
			_repo = Repo;
		}

		[RelayCommand]
		public void ToonVak(int idVak)
		{
			vak = _repo.GetVakken(true, idVak).First();
		}

		public void ToonVak()
		{
			vak.Docenten = _repo.GetVakken(true, vak.Id).FirstOrDefault()?.Docenten;
		}

		[RelayCommand]
		public async Task UploadAfbeelding()
		{
			var result = await FilePicker.Default.PickAsync();

			if (result != null)
			{
				vak.Afbeelding = result.FullPath;
			}
		}

		[RelayCommand]
		public async Task GaTerug()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
