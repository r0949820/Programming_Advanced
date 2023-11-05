using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakkenOefening.Models
{
	public class MovieSearchResult
	{
		public List<Movie> Search { get; set; } = new List<Movie>();
		public string Response { get; set; } = default!;
		public int TotalResults { get; set; } = default!;
	}
}
