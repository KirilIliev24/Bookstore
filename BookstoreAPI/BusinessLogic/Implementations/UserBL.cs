using AutoMapper;
using Bookstore.Core.Models;
using Bookstore.Core.Services.UserServices;
using BookstoreAPI.BusinessLogic.Interfaces;
using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.BusinessLogic.Implementations
{
    public class UserBL : BaseBL<UserBL>, IUserBL
    {

        private readonly IUserService _userService;
        public UserBL(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }
        //maybe use something else book model
        public Task<bool> AddBookToFavoriteAsync(string username, Book book)
        {
            throw new NotImplementedException();
        }

        //later this will return token
        public async Task<bool?> AddUserAsync(UserRequestModel user)
        {
            if (await _userService.DoesUsernameExists(user.Username))
            {
                return false;
            }
            var userToSave = Mapper.Map<User>(user);
            var userToReturn = await _userService.AddUserAsync(userToSave);
            if (userToReturn is not null)
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public Task<List<UserResponceModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponceModel?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
