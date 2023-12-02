using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakkenOefening.Models;

namespace VakkenOefening.Data
{
    public class VakRepository
    {
        public List<Vak> Vakken = new()
		{
			new Vak { Id = 1, Naam = "Vak1", Afbeelding = "vak1.png", RowNumberGrid = 1, ColumnNumberGrid = 0},
			new Vak { Id = 2, Naam = "Vak2", Afbeelding = "vak2.jpg", RowNumberGrid = 1, ColumnNumberGrid = 1},
			new Vak { Id = 3, Naam = "Vak3", Afbeelding = "vak3.jpg", RowNumberGrid = 2, ColumnNumberGrid = 0},
			new Vak { Id = 4, Naam = "Vak4", Afbeelding = "vak4.jpg", RowNumberGrid = 2, ColumnNumberGrid = 1},
			new Vak { Id = 5, Naam = "Vak5", Afbeelding = "vak5.png", RowNumberGrid = 3, ColumnNumberGrid = 0}
		};

		public List<Vak> GetVakken(bool docentenOphalen, int idVak = -1)
		{
			if (docentenOphalen)
			{
				List<Docent> alleDocenten = new DocentRepository().GetDocenten();

				Vakken[0].Docenten = new List<Docent>() { alleDocenten[0], alleDocenten[9], alleDocenten[4] };
				Vakken[1].Docenten = new List<Docent>() { alleDocenten[1], alleDocenten[8], alleDocenten[5] };
				Vakken[2].Docenten = new List<Docent>() { alleDocenten[0], alleDocenten[7], alleDocenten[6] };
				Vakken[3].Docenten = new List<Docent>() { alleDocenten[1], alleDocenten[6], alleDocenten[7] };
				Vakken[4].Docenten = new List<Docent>() { alleDocenten[0], alleDocenten[5], alleDocenten[8] };
			}

			if (idVak != -1)
			{
				return Vakken.Where(v => v.Id == idVak).ToList();
			}

			return Vakken;
		}
	}
}
