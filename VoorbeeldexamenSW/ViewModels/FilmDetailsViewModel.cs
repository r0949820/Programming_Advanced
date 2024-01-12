using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeldexamen.ViewModels
{
    [QueryProperty(nameof(Movie), "Movie")]
    public partial class FilmDetailsViewModel : BaseViewModel
    {
        HttpClient HttpClient;

        [ObservableProperty]
        Movie movie;

        [ObservableProperty]
        People people = new();

        [ObservableProperty]
        private ObservableCollection<People> peopleList = new();

        public FilmDetailsViewModel() {
            HttpClient = new HttpClient();
        }

        public async Task ZoekPeople(string url)
        {

            var response = await HttpClient.GetStringAsync(url);
            People = JsonSerializer.Deserialize<People>(response);
            
            PeopleList.Add(People);
        }

        internal async Task LoadPeople()
        {
            if(Movie != null)
            {
                foreach (var People in Movie.characters)
                {
                    await ZoekPeople(People);
                }
            }
        }
    }
}
