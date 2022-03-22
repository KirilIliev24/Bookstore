using Bookstore.Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class DBClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<User> _users;
        public DBClient(IOptions<BookstoreDbConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);
            _users = database.GetCollection<User>(bookstoreDbConfig.Value.Users_Collection_Name);
        }



        public IMongoCollection<Book> GetBookCollection() => _books;

        public IMongoCollection<User> GetUserCollection() => _users;
       
    }
}
