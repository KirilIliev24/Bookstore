﻿using Bookstore.Core.Models;
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

        //private async Task CreateIndexDefinitions()
        //{
        //    var indexKeysDefinition = Builders<User>.IndexKeys.Ascending(u => u.Username);
        //    await _users.Indexes.CreateOneAsync(new CreateIndexModel<User>(indexKeysDefinition));
        //}

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

        public async Task<bool> AddBookToFavoriteAsync(string username, Book book)
        {
            var filter = Builders<User>
             .Filter.Eq(e => e.Username, username);

            var update = Builders<User>.Update
                    .Push<Book>(e => e.FavoriteBooks, book);

            var done = await _users.FindOneAndUpdateAsync(filter, update);
            return done is not null;
        }

        public async Task<bool> DoesUsernameExists(string username)
        {
            var filter = Builders<User>.Filter.Eq<string>(u => u.Username, username);
            var exsists = await _users.Find(filter).FirstOrDefaultAsync();
            return exsists is not null;
        }
    }
}