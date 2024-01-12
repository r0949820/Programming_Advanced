using OefeningLaatsteLes.Models;

namespace OefeningLaatsteLes.Data.Repository
{
    public interface IBookRepository
    {
        public List<Book> OphalenBooksByBookId(int boekId);
    }
}
