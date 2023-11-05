using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace VakkenOefening.ViewModels
{
    public partial class MovieViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Movie> movieList = new();

        [ObservableProperty]
        private string searchValue = string.Empty;

        [ObservableProperty]
        private string yearValue = string.Empty;

        [RelayCommand]
        public async Task ToonFilms()
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

            var movies = await api.ZoekFilmOpTitel(SearchValue, jaartal);

            MovieList = new ObservableCollection<Movie>(movies);
        }

        [RelayCommand]
        public async void GaNaarImdb(Movie movie)
        {
            string url = $"https://www.imdb.com/title/{movie.imdbID}";

            //Zo open je een URL in de default browser van je platform
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
