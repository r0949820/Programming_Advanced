using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OplossingPublishers.Data.Repository;
using OplossingPublishers.Models;
using System.Collections.ObjectModel;

namespace OplossingPublishers.ViewModels
{
    public partial class EmployeesViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Employee> employees;

        [ObservableProperty]
        public ObservableCollection<Job> jobs;

        [ObservableProperty]
        public ObservableCollection<Publisher> publishers;

        [ObservableProperty]
        public Job selectedJob;

        [ObservableProperty]
        public Publisher selectedPublisher;

        [ObservableProperty]
        public string id;

        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public string pubName;
        [ObservableProperty]
        public string jobDesc;

        [ObservableProperty]
        public DateTime selectedDate = DateTime.Now;

        private IEmployeesRepository _employeesRepository;
        private IJobsRepository _jobsRepository;
        private IPublishersRepository _publishersRepository;

        public EmployeesViewModel()
        {
            _employeesRepository = new EmployeesRepository();
            _jobsRepository = new JobsRepository();
            _publishersRepository = new PublishersRepository();

            Jobs = new ObservableCollection<Job>(_jobsRepository.OphalenJobs());
            Publishers = new ObservableCollection<Publisher>(_publishersRepository.OphalenPublishers());
        }

        [RelayCommand]
        public void AlleWerknemersOphalen()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployees());
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemersOphalenViaJob()
        {
            if (SelectedJob == null)
            {
                Shell.Current.DisplayAlert("Error", "Please select a job.", "Ok");
                return;
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployeesViaJob_id(SelectedJob.Id));
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemersOphalenViaPublisher()
        {
            if (SelectedPublisher == null)
            {
                Shell.Current.DisplayAlert("Error", "Please select a publisher.", "Ok");
                return;
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployeesViaPub_id(SelectedPublisher.Id));
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemersOphalenViaJobEnPublisher()
        {
            if (SelectedJob == null)
            {
                Shell.Current.DisplayAlert("Error", "Please select a job.", "Ok");
                return;
            }

            if (SelectedPublisher == null)
            {
                Shell.Current.DisplayAlert("Error", "Please select a publisher.", "Ok");
                return;
            }

            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployeesViaPub_idEnJob_id(SelectedPublisher.Id, SelectedJob.Id));
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemersOphalenViaAanwerfdatum()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployeesViaHireDate(SelectedDate));
            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemerOphalenViaId()
        {
            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldige ID.", "Sluiten");
                return;
            }
            IsBusy = true;
            var employee = _employeesRepository.OphalenEmployeeViaPK(id);
            if (employee == null)
                Shell.Current.DisplayAlert("Fout", $"Employee met ID {id} werd niet gevonden.", "Sluiten");
            else
                Shell.Current.DisplayAlert("Employee gevonden", employee.FirstName, "Sluiten");

            IsBusy = false;
        }

        [RelayCommand]
        public void WerknemerOphalenViaNaamEnPubEnJob()
        {
            IsBusy = true;
            Employees = new ObservableCollection<Employee>(_employeesRepository.OphalenEmployeesViaNaamEnUitgeverEnJobDesc(FirstName, LastName, PubName, JobDesc));
            IsBusy = false;
        }
    }
}