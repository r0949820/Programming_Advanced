using OefeningLaatsteLes.Models;

namespace OefeningLaatsteLes.Data.Repository
{
    public interface ISaleRepository
    {
        public List<Sale> OphalenSales();

        public List<Sale> OphalenSalesById(int id);

        public List<Sale> OphalenSalesWithStoreName();
    }
}
