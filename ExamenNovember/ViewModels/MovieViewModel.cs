using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenNovember.Models;
using ExamenNovember.Views;
using System.Collections.ObjectModel;

namespace ExamenNovember.ViewModels
{
    public partial class MovieViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Movie> movieList = new();

        [ObservableProperty]
        private ObservableCollection<Movie> charrList = new();

        [ObservableProperty]
        private ObservableCollection<Movie> movies;

        [ObservableProperty]
        private Movie movie;

        [RelayCommand]
        public async Task ToonFilms()
        {
            var api = new APIs.SwAPI();

            var movies = await api.ZoekFilms();

            MovieList = new ObservableCollection<Movie>(movies);
        }

        [RelayCommand]
        public async Task ToonPersonages()
        {
            var api = new APIs.SwAPI();

            var charr = await api.ZoekCharacters();

            CharrList = new ObservableCollection<Movie>(charr);
        }

        [RelayCommand]
        public async Task OpenPersonagesPage(Movie movie)
        {
            if (movie == null)
                return;

            await Shell.Current.GoToAsync(nameof(PersonagesPage), true, new Dictionary<string, object>
            {
                {"Movie", movie }
            });
        }



    }
}
