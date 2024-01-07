using Dapper;
using OplossingPublishers.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace OplossingPublishers.Data.Repository
{
    public class PublishersRepository : BaseRepository, IPublishersRepository
    {
        public IEnumerable<Publisher> OphalenPublishers()
        {
            string sql = "SELECT * FROM Publisher ORDER BY name";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Publisher>(sql);
            }
        }
    }
}