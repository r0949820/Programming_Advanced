namespace ExamenNovember.Models
{
    public class MovieSearchResult
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Movie> results { get; set; } = new List<Movie>();
    }
}
