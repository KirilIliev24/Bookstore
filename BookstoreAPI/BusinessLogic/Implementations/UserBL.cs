using AutoMapper;
using Bookstore.Core.Models;
using Bookstore.Core.Services.UserServices;
using BookstoreAPI.BusinessLogic.Interfaces;
using BookstoreAPI.APIReqResModels.User;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.JWT;
using Bookstore.Core;

namespace BookstoreAPI.BusinessLogic.Implementations
{
    public class UserBL : BaseBL<UserBL>, IUserBL
    {

        private readonly IUserService _userService;
        private readonly IBookServices _bookServices;
        private readonly IJWTGenerator _jWTGenerator;
        public UserBL(IUserService userService, IBookServices bookServices, IJWTGenerator jWTGenerator, IMapper mapper) : base(mapper)
        {
            _userService = userService;
            _jWTGenerator = jWTGenerator;
            _bookServices = bookServices;
        }
        //maybe use something else book model
        public async Task<bool> AddBookToFavoriteAsync(string userId, string bookId)
        {
            var bookToAdd = await _bookServices.GetBookByID(bookId);
            var isSaved = await _userService.AddBookToFavoriteAsync(userId, bookToAdd);
            return isSaved;
        }

        public async Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId)
        {
            var isRemoved = await _userService.RemoveBookFromFavoriteAsync(userId, bookId);
            return isRemoved;
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

        public async Task<List<UserResponceModel>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users is not null || users.Any() == true)
            {
                var usersToReturn = Mapper.Map<List<UserResponceModel>>(users);
                return usersToReturn;
            }
            return new List<UserResponceModel>();
        }

        public async Task<List<BookResponceModel>> GetUserBooksAsync(string userId)
        {
            var booksFromDb = await _userService.GetUserBooksAsync(userId);
            if (booksFromDb is not null || booksFromDb.Any() == true)
            {
                return Mapper.Map<List<BookResponceModel>>(booksFromDb);
            }
            return new List<BookResponceModel>();

        }

        public Task<string?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
