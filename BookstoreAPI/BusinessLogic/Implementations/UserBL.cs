using AutoMapper;
using Bookstore.Core.Models;
using Bookstore.Core.Services.UserServices;
using BookstoreAPI.BusinessLogic.Interfaces;
using BookstoreAPI.APIReqResModels.User;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.JWT;
using Bookstore.Core;
using Bookstore.Core.Enums;


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
        public async Task<bool> AddBookToFavoriteAsync(string userId, string bookId)
        {
            var isBookValid = await _bookServices.DoesIdExsistsAsync(bookId);
            if(isBookValid == true)
            {
                var isSaved = await _userService.AddBookToFavoriteAsync(userId, bookId);
                return isSaved;
            }
            return false;
        }

        public async Task<bool> RemoveBookFromFavoriteAsync(string userId, string bookId)
        {
            var isRemoved = await _userService.RemoveBookFromFavoriteAsync(userId, bookId);
            return isRemoved;
        }

        public async Task<string> AddUserAsync(UserRequestModel user)
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

        public async Task<List<UserResponceModel>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync(cancellationToken);
            if (users is not null || users.Any() == true)
            {
                var usersToReturn = Mapper.Map<List<UserResponceModel>>(users);
                return usersToReturn;
            }
            return new List<UserResponceModel>();
        }

        public async Task<List<BookResponceModel>> GetUserBooksAsync(string userId)
        {
            var booksFromDB = new List<Book>();
            var idsFromDb = await _userService.GetUserBooksAsync(userId);
            if (idsFromDb is not null || idsFromDb.Any() == true)
            {
                foreach (var id in idsFromDb)
                {
                    var exsists = await _bookServices.GetBookByID(id);
                    if (exsists is not null)
                    {
                        booksFromDB.Add(exsists);
                    }
                }
                return Mapper.Map<List<BookResponceModel>>(booksFromDB);
            }
            return new List<BookResponceModel>();

        }

        public async Task<string> GetUserByUsernameAndPassAsync(string username, string password)
        {
            var user = await _userService.GetUserByUsernameAndPassAsync(username, password);
            if (user is not null)
            {
                var userToReturn = Mapper.Map<UserResponceModel>(user);
                //generate token
                var token = _jWTGenerator.GenerateJwt(userToReturn);
                return token;
            }
            else 
            {
                return String.Empty;
            }
        }

        public async Task<bool> UpdateUserRoleAsync(string userId, string userRole)
        {
            var enumCheck = Enum.IsDefined(typeof(Enums.UserRole), userRole);
            if(enumCheck is true)
            {
                var result = await _userService.UpdateUserRoleAsync(userId, userRole);
                return result;
            }
            return false;
        }
    }
}
