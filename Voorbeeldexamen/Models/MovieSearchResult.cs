using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeldexamen.Models
{

    /*  "count": 6, 
    "next": null, 
    "previous": null, 
    "results": [
    */

    public class MovieSearchResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Movie> results { get; set; } = new List<Movie>();
    }
}
