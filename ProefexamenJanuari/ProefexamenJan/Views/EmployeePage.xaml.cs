using ProefexamenJan.ViewModels;
namespace ProefexamenJan.Views;

public partial class EmployeePage : ContentPage
{
    public EmployeePage(EmployeeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}