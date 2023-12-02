using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakkenOefening.Models;

namespace VakkenOefening.ViewModels
{
    public partial class SeriesViewModel : BaseViewModel
    {
		[ObservableProperty]
		private ObservableCollection<Series> seriesList = new();

		[ObservableProperty]
		private string searchValue = string.Empty;

		[ObservableProperty]
		private string yearValue = string.Empty;

		[RelayCommand]
		public async Task ToonSeries()
		{
			var api = new APIs.OmdbAPI();

			// Default null maken en enkel opvullen indien voldoet aan voorwaarden:
			string jaartal = null;

			// Trimmen want op smartphones kunnen extra spaties komen:
			YearValue = YearValue.Trim();

			if (int.TryParse(YearValue, out _) && YearValue.Length == 4)
			{
				jaartal = YearValue;
			}

			var series = await api.ZoekSerieOpTitel(SearchValue, jaartal); 

			SeriesList = new ObservableCollection<Series>(series);
		}

		[RelayCommand]
		public async void GaNaarImdb(Series series)
		{
			string url = $"https://www.imdb.com/title/{series.imdbID}";

			try
			{
				Uri uri = new Uri(url);
				await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}
	}
}
