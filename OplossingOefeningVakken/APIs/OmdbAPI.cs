using System.Text.Json;
using VakkenOefening.Models;

namespace VakkenOefening.APIs
{
    public class OmdbAPI
    {
        private const string ApiKey = "994dfa4";
        private const string ApiUrl = "https://www.omdbapi.com/?";

        private string GetSearchQuery(string searchValue)
        {
            return $"&s={searchValue.Trim()}";
        }

        private string GetTypeQuery(string typeValue)
        {
            return $"&type={typeValue}";
        }

        private string GetYearQuery(string yearValue)
        {
            if (string.IsNullOrWhiteSpace(yearValue))
            {
                return string.Empty;
            }

            return $"&y={yearValue}";
        }

        private string GetApiKey()
        {
            return $"&apikey={ApiKey}";
        }

        public async Task<IEnumerable<Series>> ZoekSerieOpTitel(string searchValue, string yearValue = null)
        {
            var seriesList = new List<Series>();

            using (HttpClient HttpClient = new())
            {
                var apiUrl = ApiUrl;

                apiUrl += GetSearchQuery(searchValue).Remove(0, 1);
                apiUrl += GetTypeQuery("series");
                apiUrl += GetYearQuery(yearValue);
                apiUrl += GetApiKey();

                var response = await HttpClient.GetStringAsync(apiUrl);
                SeriesSearchResult result = JsonSerializer.Deserialize<SeriesSearchResult>(response);

                foreach (var series in result.Search)
                {
                    seriesList.Add(series);
                }
            }

            return seriesList;
        }

        public async Task<IEnumerable<Movie>> ZoekFilmOpTitel(string searchValue, string yearValue = null)
        {
            var movieList = new List<Movie>();

            using (HttpClient HttpClient = new())
            {
                var apiUrl = ApiUrl;

                apiUrl += GetSearchQuery(searchValue).Remove(0, 1);
                apiUrl += GetTypeQuery("movie");
                apiUrl += GetYearQuery(yearValue);
                apiUrl += GetApiKey();

                var response = await HttpClient.GetStringAsync(apiUrl);
                MovieSearchResult result = JsonSerializer.Deserialize<MovieSearchResult>(response);

                foreach (var movie in result.Search)
                {
                    movieList.Add(movie);
                }
            }

            return movieList;
        }
    }
}
