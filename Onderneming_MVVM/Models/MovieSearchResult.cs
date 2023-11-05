namespace Onderneming_MVVM.Models
{
    public class MovieSearchResult
    {
        public List<Movie> Search { get; set; } = new List<Movie>();
        public string Response { get; set; } = default!;
        public int TotalResults { get; set; } = default!;
    }
}
