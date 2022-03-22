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
        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<User?> AddUserAsync(User user);
        Task<User> GetUserByUsernameAndPassAsync(string username, string password);
        Task<List<Book>> GetUserBooksAsync(string userId);
        Task<bool> AddBookToFavoriteAsync(string userId, Book book);
        Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId);
        Task<bool> RemoveFromEveryoneAsync(string bookId);
        Task<bool> DoesUsernameExists(string username);
        Task<bool> UpdateUserRoleAsync(string userId, string userRole);
    }
}
