using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        Task<List<UserResponceModel>> GetAllUsersAsync();
        Task<string?> AddUserAsync(UserRequestModel user);
        Task<string?> GetUserByUsernameAsync(string username);
        Task<List<BookResponceModel>> GetUserBooksAsync(string username);
        Task<bool> AddBookToFavoriteAsync(string username, Book book);
    }
}
