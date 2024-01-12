using ProefexamenJan.Models;

namespace ProefexamenJan.Data.Repository
{
    public interface IBookRepository
    {
        public List<Book> OphalenBooks();
        public List<TitleAuthor> OphalenBooksAndAuthor();
    }
}
