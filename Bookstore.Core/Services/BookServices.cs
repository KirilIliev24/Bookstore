using Bookstore.Core.Models;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IDbClient dbClient)
        {
            _books = dbClient.GetBookCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public List<Book> GetBooks() => _books.Find(book => true).ToList();
        
    }
}