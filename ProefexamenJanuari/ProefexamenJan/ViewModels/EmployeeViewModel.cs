using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProefexamenJan.Data.Repository;
using ProefexamenJan.Models;
using System.Collections.ObjectModel;

namespace ProefexamenJan.ViewModels
{
    public partial class EmployeeViewModel : BaseViewModel
    {
        private IEmployeeRepository _employeeRepository;

        [ObservableProperty]
        private ObservableCollection<Employee> employees;

        [ObservableProperty]
        private ObservableCollection<Employee> employeesJob;

        public EmployeeViewModel()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [RelayCommand]
        public void OphalenEmployeesUSA()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeeRepository.OphalenEmployeesUSA());
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenEmployeesJobDesc()
        {
            IsBusy = true;
            EmployeesJob = new ObservableCollection<Employee>(_employeeRepository.OphalenEmployeesJobDesc());
            IsBusy = false;
        }
    }
}
