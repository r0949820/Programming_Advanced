/*
 * Interface en repository
Voorzie een interface en repository voor de tabel Store. Volgende methodes moeten aanwezig zijn:

public List<Store> OphalenStoresViaStaat(string staat);
public List<Store> OphalenStoresViaNaam(string naam);
public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat);
public Store OphalenStoreViaId(int id);
 */
using Dapper;
using OefeningPublishers.Models;
using System.Data;
using System.Data.SqlClient;

namespace OefeningPublishers.Data.Repository
{
    public class StoreRepository : BaseRepository, IStore
    {


        public List<Store> OphalenStoresViaNaam(string naam)
        {
            string sql = @"SELECT * FROM Store WHERE name like '%' + @name + '%' ORDER BY name";

            var parameters = new { @name = naam };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }
        public List<Store> OphalenStoresViaStaat(string staat)
        {
            string sql = @"SELECT * FROM Store WHERE state like '%' + @state + '%' ORDER BY name";

            var parameters = new { @state = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }
        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat)
        {

            string sql = @"SELECT *";
            sql += " FROM Store";
            sql += " WHERE name like '%'+ @name +'%'";
            sql += " AND state like '%'+ @state + '%'";
            sql += " ORDER BY name";

            var parameters = new { @name = naam, @state = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public Store OphalenStoreViaId(int storeID)
        {
            string sql = @"SELECT * FROM  Store WHERE id = @id";

            var parameters = new { @id = storeID };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Store>(sql, parameters);
            }
        }
    }
}
