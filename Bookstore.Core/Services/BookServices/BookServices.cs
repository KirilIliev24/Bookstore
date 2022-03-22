﻿using Bookstore.Core.Models;
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
    }
}