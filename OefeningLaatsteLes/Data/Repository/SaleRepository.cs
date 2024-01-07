using Dapper;
using Microsoft.Data.SqlClient;
using OefeningLaatsteLes.Models;
using System.Data;

namespace OefeningLaatsteLes.Data.Repository
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        public List<Sale> OphalenSales()
        {
            string sql = "SELECT * FROM Sale";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Sale>(sql).ToList();
            }
        }

        public List<Sale> OphalenSalesById(int id)
        {
            string sql = "SELECT * FROM Sale WHERE Id=@id";

            var parameters = new { @id = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Sale>(sql, parameters).ToList();
            }
        }

        public List<Sale> OphalenSalesWithStoreName()
        {
            string sql = "SELECT Sa.*, St.* FROM Sale Sa" +
                        " INNER JOIN Store St ON Sa.storeId = St.id";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Sale, Store, Sale>(
                    sql,
                    (sale, store) =>
                    {
                        sale.Store = store;
                        return sale;
                    },
                    splitOn: "Id"
                    ).ToList();
            }
        }
    }
}