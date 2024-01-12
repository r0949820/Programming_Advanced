namespace Voorbereiding_ExamenJan.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int KlantId { get; set; }
        public int? WerknemerId { get; set; }
        public DateTime? Orderdatum { get; set; }
        public string Verzendadres { get; set; }
        public string Verzendplaats { get; set; }
        public string Verzendpostcode { get; set; }
        public string Verzendland { get; set; }


        public Klant Klant { get; set; }
        public Werknemer Werknemer { get; set; }
    }
}
