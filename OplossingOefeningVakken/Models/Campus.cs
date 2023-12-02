using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakkenOefening.Models
{
    public class Campus
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string Postcode { get; set; }

        public string Gemeente { get; set; }
    }
}
