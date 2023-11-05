using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VakkenOefening.Models
{
    public partial class Vak : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string naam;

        [ObservableProperty]
        private string afbeelding;

        [ObservableProperty]
        private bool heeftVastLokaal;

		[ObservableProperty]
		private char vastLokaalBlok;

		[ObservableProperty]
		private int vastLokaalNummer;

		[ObservableProperty]
		private int verwachteScore;

		[ObservableProperty]
		private int rowNumberGrid;

		[ObservableProperty]
		private int columnNumberGrid;

        [ObservableProperty]
        private DateTime datumEersteLes;

        [ObservableProperty]
        private IEnumerable<Docent> docenten;

        public IEnumerable<Student> Studenten { get; set; }

        public Campus Locatie { get; set; }
    }
}
