using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProefexamenJan.Data.Repository;
using ProefexamenJan.Models;
using System.Collections.ObjectModel;

namespace ProefexamenJan.ViewModels
{
    public partial class BookViewModel : BaseViewModel
    {
        private IBookRepository _bookRepository;

        [ObservableProperty]
        private ObservableCollection<Book> books;

        [ObservableProperty]
        private ObservableCollection<TitleAuthor> titleAuthors;

        public BookViewModel()
        {
            _bookRepository = new BookRepository();
        }

        [RelayCommand]
        public void OphalenBooks()
        {
            IsBusy = true;
            Books = new ObservableCollection<Book>(_bookRepository.OphalenBooks());
            IsBusy = false;
        }

        [RelayCommand]
        public void OphalenBooksAndAuthor()
        {
            IsBusy = true;
            TitleAuthors = new ObservableCollection<TitleAuthor>(_bookRepository.OphalenBooksAndAuthor());
            IsBusy = false;
        }
    }
}
