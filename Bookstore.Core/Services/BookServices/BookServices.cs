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

        public async Task<Book> AddBook(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }

        public async Task<Book> GetBookByID(string id) => await _books.Find(book => book.Id == id).FirstOrDefaultAsync();

        public async Task<List<Book>> GetBooks() => await _books.Find(book => true).ToListAsync();

        public async Task<bool> DeleteByIdAsync(string id)
        {
            var isDeleted = await _books.DeleteOneAsync(b => b.Id == id);
            return isDeleted.IsAcknowledged;
        }

        public async Task<bool> DoesIdExsistsAsync(string id)
        {
            var filter = Builders<Book>.Filter.Eq<string>(u => u.Id, id);
            var exsists = await _books.Find(filter).FirstOrDefaultAsync();
            return exsists is not null;
        }

        public async Task<Book> UpdateByIdAsync(Book newBook, string id)
        {
            var filter = Builders<Book>.Filter.Eq<string>(b => b.Id, newBook.Id);
            var result = await _books.FindOneAndReplaceAsync(filter, newBook, new FindOneAndReplaceOptions<Book> { ReturnDocument = ReturnDocument.After });
            return result;
        }
    }
}