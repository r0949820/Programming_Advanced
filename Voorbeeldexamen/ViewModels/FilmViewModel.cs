using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Voorbeeldexamen.ViewModels
{
    public partial class FilmViewModel : BaseViewModel
    {
        HttpClient HttpClient;

        [ObservableProperty]
        private ObservableCollection<Movie> movieList = new();

        [ObservableProperty]
        private Movie movie;

        MovieSearchResult MovieSearchResult = new();

        public FilmViewModel()
        {
            HttpClient = new HttpClient();
            Movie = new Movie();
        }

        [RelayCommand]
        public async void ZoekFilms()
        {
            //var zoekwaarde = "King";
            var apiUrl = "https://swapi.dev/api/films/";

            var response = await HttpClient.GetStringAsync(apiUrl);
            MovieSearchResult = JsonSerializer.Deserialize<MovieSearchResult>(response);

            foreach (var movie in MovieSearchResult.results)
                MovieList.Add(movie);
        }

        [RelayCommand]
        public async Task VoegFilmToe()
        {
            if (Movie == null)
                return;
            MovieList.Add(Movie);
            await GoBackAsync();
        }

        [RelayCommand]
        public void VerwijderFilm(Movie movie)
        {
            if (movie == null)
                return;
            MovieList.Remove(movie);
        }

        [RelayCommand]
        public void GoToToevoegen()
        {
            Shell.Current.GoToAsync(nameof(VoegFilmToeView), true);
        }

        [RelayCommand]
        async Task GoToDetails(Movie movie)
        {
            if (movie == null)
                return;
            await Shell.Current.GoToAsync(nameof(FilmDetailView), true, new Dictionary<string, object>
        {
            {"Movie", movie }
        });

        }
    }
}
