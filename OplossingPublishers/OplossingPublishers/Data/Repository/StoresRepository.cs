using Dapper;
using Microsoft.Data.SqlClient;
using OplossingPublishers.Models;
using System.Data;

namespace OplossingPublishers.Data.Repository
{
    public class StoresRepository : BaseRepository, IStoresRepository
    {
        public List<Store> OphalenStoresViaNaam(string naam)
        {
            string sql = "SELECT * FROM Store";
            sql += " WHERE name like '%'+ @naam +'%'";
            sql += " ORDER BY name";

            var parameters = new { @naam = naam };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat)
        {
            string sql = "SELECT * FROM Store";
            sql += " WHERE name like '%'+ @naam +'%'";
            sql += " AND state=@staat";
            sql += " ORDER BY name";

            var parameters = new { @naam = naam, @staat = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public List<Store> OphalenStoresViaStaat(string staat)
        {
            string sql = "SELECT * FROM Store WHERE state=@staat ORDER BY name";

            var parameters = new { @staat = staat };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }

        public Store OphalenStoreViaId(int id)
        {
            string sql = "SELECT * FROM Store WHERE Id=@id";

            var parameters = new { @id = id };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).SingleOrDefault();
            }
        }

        public List<Store> OphalenStoresViaNaamEnAdres(string naam, string zip, string city)
        {
            string sql = "SELECT * FROM Store";
            sql += " WHERE name like '%'+ @naam +'%'";
            sql += " AND zip=@zip";
            sql += " AND city=@city";
            sql += " ORDER BY name";

            var parameters = new { @naam = naam, @zip = zip, @city = city };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Store>(sql, parameters).ToList();
            }
        }
    }
}