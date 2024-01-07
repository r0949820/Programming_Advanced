using Dapper;
using Microsoft.Data.SqlClient;
using OplossingPublishers.Models;
using System.Data;

namespace OplossingPublishers.Data.Repository
{
    public class JobsRepository : BaseRepository, IJobsRepository
    {
        public IEnumerable<Job> OphalenJobs()
        {
            string sql = "SELECT * FROM job ORDER BY description";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Job>(sql);
            }
        }
    }
}