using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OplossingPublishers.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public short Amount { get; set; }
        public int BookId { get; set; }

        public Store Store { get; set; }
        public Book Book { get; set; }
    }
}