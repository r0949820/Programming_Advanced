using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakkenOefening.Models
{
    public class SeriesSearchResult
	{
		public List<Series> Search { get; set; } = new List<Series>();
		public string Response { get; set; } = default!;
		public int TotalResults { get; set; } = default!;
    }
}
