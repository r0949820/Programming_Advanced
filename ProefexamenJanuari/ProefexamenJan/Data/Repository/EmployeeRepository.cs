using Dapper;
using Microsoft.Data.SqlClient;
using ProefexamenJan.Models;
using System.Data;

namespace ProefexamenJan.Data.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        // Employees waar de publisher in USA woont
        public List<Employee> OphalenEmployeesUSA()
        {
            string sql = @"SELECT E.*, P.* FROM Employee E JOIN Publisher P ON E.publisherId = P.id WHERE P.country = 'USA'";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var debugVar = db.Query<Employee, Publisher, Employee>(
                    sql,
                    (employee, publisher) =>
                    {
                        employee.Publisher = publisher;
                        return employee;
                    },
                    splitOn: "Id"
                    );
                return debugVar.ToList();
            }
        }

        //Haal mij alle employees op waarbij het min level groter is dan 100 en het max level kleiner of gelijk is aan 225 
        public List<Employee> OphalenEmployeesJobDesc()
        {
            string sql = @"SELECT E.*, J.* FROM Employee E JOIN Job J ON E.jobId = J.id WHERE J.minLevel > 100 AND J.maxLevel <= 225";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var debugVar = db.Query<Employee, Job, Employee>(
                    sql,
                    (employee, job) =>
                    {
                        employee.Job = job;
                        return employee;
                    },
                    splitOn: "Id"
                    );
                return debugVar.ToList();
            }
        }
    }
}
