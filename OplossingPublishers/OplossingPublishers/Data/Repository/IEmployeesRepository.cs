using OplossingPublishers.Models;

namespace OplossingPublishers.Data.Repository
{
    public interface IEmployeesRepository
    {
        public IEnumerable<Employee> OphalenEmployees();

        public List<Employee> OphalenEmployeesViaHireDate(DateTime hiredate);

        public List<Employee> OphalenEmployeesViaJob_id(int jobId);

        public List<Employee> OphalenEmployeesViaPub_id(int id);

        public List<Employee> OphalenEmployeesViaPub_idEnJob_id(int pubId, int jobId);

        public Employee OphalenEmployeeViaPK(int id);

        public IEnumerable<Employee> OphalenEmployeesViaNaamEnUitgeverEnJobDesc(string firstName, string lastName, string pubName, string jobDesc);
    }
}