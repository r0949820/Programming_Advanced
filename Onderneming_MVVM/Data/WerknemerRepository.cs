namespace Onderneming_MVVM.Data
{
    public class WerknemerRepository
    {
        // Lijst met werknemers
        public List<Werknemer> Werknemers = new()
        {
            new Werknemer() { Voornaam = "John", Achternaam = "Doe", Functie = "Manager", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-1.png" },
            new Werknemer() { Voornaam = "Linn", Achternaam = "Kendal", Functie = "Coordinator", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-2.png" },
            new Werknemer() { Voornaam = "Mark", Achternaam = "Mathys", Functie = "Verkoper", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-3.png" },
            new Werknemer() { Voornaam = "Lenno", Achternaam = "Brimelow", Functie = "Verkoper", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-4.png" },
            new Werknemer() { Voornaam = "Theresa", Achternaam = "Korf", Functie = "Verkoper", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-5.png" },
            new Werknemer() { Voornaam = "Natalie", Achternaam = "Spurway", Functie = "Verkoper", Avatar = "https://raw.githubusercontent.com/it-graduaten/ProgrammingAdvanced-StarterRepo/main/public-resources/avatars/avatar-6.png" }
        };

        // Methode om de werknemers op te vragen
        public List<Werknemer> GetWerknemers()
        {
            return Werknemers;
        }
    }


}
