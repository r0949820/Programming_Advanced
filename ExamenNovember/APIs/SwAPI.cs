using ExamenNovember.Models;
using System.Text.Json;

namespace ExamenNovember.APIs
{
    public class SwAPI
    {

        public async Task<IEnumerable<Movie>> ZoekFilms()
        {
            var movieList = new List<Movie>();
            var apiUrl = $"https://swapi.dev/api/films";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                MovieSearchResult result = JsonSerializer.Deserialize<MovieSearchResult>(response);

                foreach (var movie in result.results)
                    movieList.Add(movie);
            }

            return movieList;
        }

        public async Task<IEnumerable<Movie>> ZoekCharacters()
        {
            var charList = new List<Movie>();
            var url = $"https://swapi.dev/api/people/";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                MovieSearchResult result = JsonSerializer.Deserialize<MovieSearchResult>(response);

                foreach (var charr in result.results)
                {
                    charList.Add(charr);
                }
                return charList;
            }
        }
    }
}
