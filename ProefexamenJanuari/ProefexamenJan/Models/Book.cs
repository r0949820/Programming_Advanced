namespace ProefexamenJan.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int PublisherId { get; set; }
        public decimal Price { get; set; }
        public decimal Advance { get; set; }
        public int Royalty { get; set; }
        public int Sales { get; set; }
        public string Notes { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Publisher Publisher { get; set; }
    }
}
