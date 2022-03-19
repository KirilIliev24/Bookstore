using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        Task<List<UserResponceModel>> GetAllUsersAsync();
        Task<bool?> AddUserAsync(UserRequestModel user);
        Task<UserResponceModel?> GetUserByUsernameAsync(string username);
        Task<bool> AddBookToFavoriteAsync(string username, Book book);
    }
}
