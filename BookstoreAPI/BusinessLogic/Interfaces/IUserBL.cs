using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        Task<List<UserResponceModel>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<string> AddUserAsync(UserRequestModel user);
        Task<string> GetUserByUsernameAndPassAsync(string username, string password);
        Task<List<BookResponceModel>> GetUserBooksAsync(string userId);
        Task<bool> AddBookToFavoriteAsync(string userId, string bookId);
        Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId);
        Task<bool> UpdateUserRoleAsync(string userId, string userRole);

    }
}
