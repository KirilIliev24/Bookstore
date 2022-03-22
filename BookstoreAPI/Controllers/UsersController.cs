using Bookstore.Core.Enums;
using BookstoreAPI.APIReqResModels.User;
using BookstoreAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBL _userBL;
        public UsersController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet(nameof(GetAllUsers))]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userBL.GetAllUsersAsync(cancellationToken);
            return users is not null ? StatusCode(StatusCodes.Status200OK, users) : StatusCode(StatusCodes.Status400BadRequest, "No users found");
        }
        
        [HttpGet(nameof(GetUserBooks))]
        public async Task<ActionResult> GetUserBooks([FromQuery] string userId)
        {
            var books = await _userBL.GetUserBooksAsync(userId);
            return books is not null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest, "No books found");
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] UserRequestModel user)
        {
            var userToken = await _userBL.AddUserAsync(user);
            return userToken != String.Empty ? StatusCode(StatusCodes.Status200OK, userToken) : StatusCode(StatusCodes.Status400BadRequest, "Username not available");
        }


        [HttpPost(nameof(Login))]
        public async Task<ActionResult> Login(string username, string hashPassword)
        {
            var userToken = await _userBL.GetUserByUsernameAndPassAsync(username, hashPassword);
            return userToken != String.Empty? StatusCode(StatusCodes.Status200OK, userToken) : StatusCode(StatusCodes.Status400BadRequest, "Username or password are wrong");
        }

        [HttpPatch(nameof(UpdateUserRole))]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateUserRole(string userId, string userRole)
        {
            var isUpdated = await _userBL.UpdateUserRoleAsync(userId, userRole);
            return isUpdated? StatusCode(StatusCodes.Status200OK, isUpdated) : StatusCode(StatusCodes.Status400BadRequest, "User role or user is not valid");
        }

        [HttpPut(nameof(AddBookToUser))]
        public async Task<ActionResult> AddBookToUser(string userId, string bookId)
        {
            var isSaved = await _userBL.AddBookToFavoriteAsync(userId, bookId);
            return isSaved ? StatusCode(StatusCodes.Status200OK, isSaved) : StatusCode(StatusCodes.Status400BadRequest, "Book was not saved");
        }

        [HttpPut(nameof(RemoveBookFromUser))]
        public async Task<ActionResult> RemoveBookFromUser(string userId, string bookId)
        {
            var isRemoved = await _userBL.RemoveBookFromFavoriteAsync(userId, bookId);
            return isRemoved? StatusCode(StatusCodes.Status200OK, isRemoved) : StatusCode(StatusCodes.Status400BadRequest, "Book was not removed");
        }
    }
}
