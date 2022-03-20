using Bookstore.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDbClient dbClient)
        {
            _users = dbClient.GetUserCollection();
            
        }

        public async Task<User?> AddUserAsync(User user)
        {
            try
            {
                await _users.InsertOneAsync(user);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public async Task<List<User>> GetAllUsersAsync() => await _users.Find(u => true).ToListAsync();

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _users.Find(u => u.Username == username).FirstAsync();
        }

        public async Task<bool> AddBookToFavoriteAsync(string userId, Book book)
        {
            var filter = Builders<User>
             .Filter.Eq(e => e.Id, userId);

            var update = Builders<User>.Update
                    .Push<Book>(e => e.FavoriteBooks, book);

            var done = await _users.FindOneAndUpdateAsync(filter, update);
            return done is not null;
        }

        public async Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId)
        {
            var filter = Builders<User>
             .Filter.Eq(e => e.Id, userId);

            var update = Builders<User>.Update
                    .PullFilter<Book>(e => e.FavoriteBooks,
                        Builders<Book>.Filter.Eq(b => b.Id, bookId));

            var done = await _users.FindOneAndUpdateAsync(filter, update);
            return done is not null;
        }

        public async Task<bool> DoesUsernameExists(string username)
        {
            var filter = Builders<User>.Filter.Eq<string>(u => u.Username, username);
            var exsists = await _users.Find(filter).FirstOrDefaultAsync();
            return exsists is not null;
        }

        public async Task<List<Book>> GetUserBooksAsync(string userId)
        {
            var filter = Builders<User>.Filter.Eq<string>(u => u.Id, userId);
            var user = await _users.Find(filter).FirstOrDefaultAsync();
            return user.FavoriteBooks.ToList();
            
        }
    }
}
