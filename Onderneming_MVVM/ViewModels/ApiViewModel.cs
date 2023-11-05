using Microcharts;

namespace Onderneming_MVVM.ViewModels
{
    public partial class ApiViewModel : BaseViewModel
    {
        HttpClient HttpClient;

        [ObservableProperty]
        private ObservableCollection<Movie> movieList = new();
        [ObservableProperty]
        private Chart grafiek;

        private List<ChartEntry> entries = new();
        MovieSearchResult MovieSearchResult = new();
        WeerData WeerData = new();


        public ApiViewModel()
        {
            HttpClient = new HttpClient();
        }

        [RelayCommand]
        public async Task ZoekFilms()
        {
            var apiKey = "9aa2196e"; // Jouw API-key
            var zoekwaarde = "King";
            var apiUrl = $"https://www.omdbapi.com/?s={zoekwaarde}&type=movie&apikey={apiKey}";

            var response = await HttpClient.GetStringAsync(apiUrl);
            MovieSearchResult = JsonSerializer.Deserialize<MovieSearchResult>(response);

            foreach (var movie in MovieSearchResult.Search)
                MovieList.Add(movie);
        }

        [RelayCommand]
        public async void WeerOpvragen()
        {
            var apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=51.1656&longitude=4.9892&hourly=temperature_2m";

            try
            {
                var response = await HttpClient.GetStringAsync(apiUrl);
                WeerData = JsonSerializer.Deserialize<WeerData>(response);

                var aantal = WeerData.hourly.temperature_2m.Count;

                for (var i = 0; i < aantal; i++)
                {
                    var label = i % 10 == 0 ? WeerData.hourly.time[i].ToString() : "";
                    var valueLabel = i % 10 == 0 ? WeerData.hourly.temperature_2m[i].ToString() : "";
                    entries.Add(new ChartEntry((WeerData.hourly.temperature_2m[i])) { Label = label, ValueLabel = valueLabel });
                }

                Grafiek = new LineChart
                {
                    Entries = entries,
                    LineMode = LineMode.Straight,
                    PointMode = PointMode.Circle,
                    PointSize = 0,
                    /*ValueLabelOption = ValueLabelOption.None,
                    ShowYAxisText = true,
                    ShowYAxisLines = true,
                    YAxisPosition = Position.Left*/
                };
            }
            catch (Exception ex) { }
        }
    }
}

