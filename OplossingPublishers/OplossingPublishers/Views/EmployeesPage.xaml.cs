using OplossingPublishers.ViewModels;

namespace OplossingPublishers.Views;

public partial class EmployeesPage : ContentPage
{
    public EmployeesPage(EmployeesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}