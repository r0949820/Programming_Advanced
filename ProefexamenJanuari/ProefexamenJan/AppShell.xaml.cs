using ProefexamenJan.Views;

namespace ProefexamenJan
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
        }
    }
}