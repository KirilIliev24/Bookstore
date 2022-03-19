using Bookstore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> AddUserAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> AddBookToFavoriteAsync(string username, Book book);
        Task<bool> DoesUsernameExists(string username);
    }
}
