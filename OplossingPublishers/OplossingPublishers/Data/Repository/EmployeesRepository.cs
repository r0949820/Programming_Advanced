using Dapper;
using Microsoft.Data.SqlClient;
using OplossingPublishers.Models;
using System.Data;

namespace OplossingPublishers.Data.Repository
{
    public class EmployeesRepository : BaseRepository, IEmployeesRepository
    {
        public IEnumerable<Employee> OphalenEmployees()
        {
            string sql = "SELECT * FROM Employee ORDER BY lastName, firstName";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql);
            }
        }

        public List<Employee> OphalenEmployeesViaHireDate(DateTime hiredate)
        {
            string sql = "SELECT * FROM Employee WHERE hireDate <= @hiredate ORDER BY lastName, firstName";
            var parameters = new { @hiredate = hiredate };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaJob_id(int id)
        {
            string sql = "SELECT * FROM Employee WHERE jobId = @jobId ORDER BY lastName, firstName";
            var parameters = new { @jobId = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaPub_id(int id)
        {
            string sql = "SELECT * FROM Employee WHERE publisherId = @id ORDER BY lastName, firstName";
            var parameters = new { @id = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public List<Employee> OphalenEmployeesViaPub_idEnJob_id(int pubId, int jobId)
        {
            string sql = "SELECT * FROM Employee " +
                "WHERE publisherId = @pubId " +
                "AND (@jobId = jobId OR @jobId=0) " +
                "ORDER BY lastName, firstName";
            var parameters = new { @pubId = pubId, @jobId = jobId };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, parameters).AsList();
            }
        }

        public Employee OphalenEmployeeViaPK(int id)
        {
            string sql = "SELECT * FROM Employee WHERE id = @id";
            var parameters = new { @id = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.QuerySingleOrDefault<Employee>(sql, parameters);
            }
        }

        public IEnumerable<Employee> OphalenEmployeesViaNaamEnUitgeverEnJobDesc(string firstName, string lastName, string pubName, string jobDesc)
        {
            string sql = "SELECT E.*, P.*, J.* FROM Employee E " +
                "INNER JOIN Publisher P ON E.publisherId = P.Id" +
                "INNER JOIN Job J ON E.jobId = J.Id" +
                "WHERE E.firstName LIKE '%' + @firstName + '%'" +
                "AND E.lastName LIKE '%' + @lastName + '%'" +
                "AND P.name LIKE '%' + @pubName + '%'" +
                "AND J.description LIKE '%' + @jobDesc + '%'" +
                "ORDER BY firstName";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee, Publisher, Job, Employee>(
                    sql,
                    (employee, publisher, job) =>
                    {
                        employee.Publisher = publisher;
                        employee.Job = job;
                        return employee;
                    },
                    new { firstName = firstName, lastName = lastName, pubName = pubName, jobDesc = jobDesc }
                    );
            }
        }
    }
}