using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OefeningLaatsteLes.Data.Repository;
using OefeningLaatsteLes.Models;
using System.Collections.ObjectModel;

namespace OefeningLaatsteLes.ViewModels
{
    public partial class SaleViewModel : BaseViewModel
    {
        private ISaleRepository _saleRepository;
        private IBookRepository _bookRepository;

        [ObservableProperty]
        private ObservableCollection<Sale> sales;

        [ObservableProperty]
        private ObservableCollection<Book> books;

        private Sale selectedSale;

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string bookId;

        [ObservableProperty]
        private Book book;

        public SaleViewModel()
        {
            _saleRepository = new SaleRepository();
            _bookRepository = new BookRepository();

            Sales = new ObservableCollection<Sale>();
            Books = new ObservableCollection<Book>();
        }

        [RelayCommand]
        public void OphalenSales()
        {
            IsBusy = true;
            Sales = new ObservableCollection<Sale>(_saleRepository.OphalenSales());
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenSalesViaId()
        {
            if (!int.TryParse(Id, out int id))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldige ID.", "Sluiten");
                return;
            }
            IsBusy = true;
            var sale = _saleRepository.OphalenSalesById(id);
            if (sale == null)
                Shell.Current.DisplayAlert("Fout", $"Sale met ID {id} werd niet gevonden.", "Sluiten");
            else
                Shell.Current.DisplayAlert("Sale gevonden", sale.ToString(), "Sluiten");

            IsBusy = false;
        }

        [RelayCommand]
        public void SalesOphalenWithStoreName()
        {
            IsBusy = true;
            Sales = new ObservableCollection<Sale>(_saleRepository.OphalenSalesWithStoreName());
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenBooksByBookId()
        {
            if (!int.TryParse(BookId, out int bookId))
            {
                Shell.Current.DisplayAlert("Fout", "Geef een geldige ID.", "Sluiten");
                return;
            }
            IsBusy = true;
            var book = _bookRepository.OphalenBooksByBookId(bookId);
            if (book == null)
                Shell.Current.DisplayAlert("Fout", $"Boek met ID {bookId} werd niet gevonden.", "Sluiten");
            else
                Shell.Current.DisplayAlert("Boek gevonden", book.ToString(), "Sluiten");

            IsBusy = false;
        }

    }
}
