using ProefexamenJan.Models;

namespace ProefexamenJan.Data.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> OphalenEmployeesUSA();

        public List<Employee> OphalenEmployeesJobDesc();
    }
}
