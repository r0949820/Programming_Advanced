using Dapper;
using Microsoft.Data.SqlClient;
using OefeningLaatsteLes.Models;
using System.Data;

namespace OefeningLaatsteLes.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public List<Book> OphalenBooksByBookId(int boekId)
        {
            string sql = "SELECT B.*, P.* FROM Book B" +
                              "INNER JOIN Publisher P ON B.publisherId = P.id" +
                              "WHERE B.id=@boekId";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Book, Publisher, Book>(
                    sql,
                    (book, publisher) =>
                    {
                        book.Publisher = publisher;
                        return book;
                    },
                    new { boekId = boekId }
                    ).ToList();
            }

        }
    }
}
