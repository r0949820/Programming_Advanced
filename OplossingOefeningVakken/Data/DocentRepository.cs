using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakkenOefening.Models;

namespace VakkenOefening.Data
{
    public class DocentRepository
    {
		public List<Docent> Docenten = new()
		{
			new Docent() { Id = 1, Naam = "Van Dingenen", Voornaam = "Evelien" },
			new Docent() { Id = 2, Naam = "Moonen", Voornaam = "Maarten" },
			new Docent() { Id = 3, Naam = "Synaeve", Voornaam = "Joren" },
			new Docent() { Id = 4, Naam = "Ooms", Voornaam = "Bart" },
			new Docent() { Id = 5, Naam = "Caers", Voornaam = "Maxim" },
			new Docent() { Id = 6, Naam = "Hendrickx", Voornaam = "Indy" },
			new Docent() { Id = 7, Naam = "Claessen", Voornaam = "Matthias" },
			new Docent() { Id = 8, Naam = "Verlooy", Voornaam = "Joeri" },
			new Docent() { Id = 9, Naam = "Willekens", Voornaam = "Stijn" },
			new Docent() { Id = 10, Naam = "Mangelschots", Voornaam = "Niels" }
		};

		public List<Docent> GetDocenten()
		{
			return Docenten;
		}
	}
}
