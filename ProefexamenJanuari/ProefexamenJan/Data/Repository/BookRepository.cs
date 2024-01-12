using Dapper;
using Microsoft.Data.SqlClient;
using ProefexamenJan.Models;
using System.Data;

namespace ProefexamenJan.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public List<Book> OphalenBooks()
        {
            string sql = "SELECT * FROM Book ORDER BY price, releaseDate";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Book>(sql).ToList();
            }
        }


        public List<TitleAuthor> OphalenBooksAndAuthor()
        {
            string sql = "SELECT TA.*, B.* ,  A.* FROM Book B JOIN TitleAuthor TA ON B.id = TA.bookId JOIN Author A ON TA.authorId = A.id";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var debugVar = db.Query<TitleAuthor, Book, Author, TitleAuthor>(
                    sql,
                    (titleAuthor, book, author) =>
                    {
                        titleAuthor.Book = book;
                        titleAuthor.Author = author;
                        return titleAuthor;
                    },
                    splitOn: "Id"
                );
                return debugVar.ToList();
            }
        }
    }
}
