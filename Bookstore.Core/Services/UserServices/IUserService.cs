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
        Task<List<Book>> GetUserBooksAsync(string userId);
        Task<bool> AddBookToFavoriteAsync(string userId, Book book);
        Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId);
        Task<bool> DoesUsernameExists(string username);
        Task<bool> UpdateUserRoleAsync(string userId, string userRole);
    }
}
