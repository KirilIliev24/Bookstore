using AutoMapper;
using Bookstore.Core.Models;
using Bookstore.Core.Services.UserServices;
using BookstoreAPI.BusinessLogic.Interfaces;
using BookstoreAPI.APIReqResModels.User;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.JWT;

namespace BookstoreAPI.BusinessLogic.Implementations
{
    public class UserBL : BaseBL<UserBL>, IUserBL
    {

        private readonly IUserService _userService;
        private readonly IJWTGenerator _jWTGenerator;
        public UserBL(IUserService userService, IJWTGenerator jWTGenerator, IMapper mapper) : base(mapper)
        {
            _userService = userService;
            _jWTGenerator = jWTGenerator;
        }
        //maybe use something else book model
        public async Task<bool> AddBookToFavoriteAsync(string username, Book book)
        {
            throw new NotImplementedException();
        }

        //later this will return token
        public async Task<string?> AddUserAsync(UserRequestModel user)
        {
            if (await _userService.DoesUsernameExists(user.Username))
            {
                return String.Empty;
            }
            var userToSave = Mapper.Map<User>(user);
            var userFromDB = await _userService.AddUserAsync(userToSave);
            if (userFromDB is not null)
            {
                var userToReturn = Mapper.Map<UserResponceModel>(userFromDB);
                //generate token
                var token = _jWTGenerator.GenerateJwt(userToReturn);
                return token;
            }
            else 
            {
                return String.Empty;
            }
            
        }

        public Task<List<UserResponceModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BookResponceModel>> GetUserBooksAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
