using BookstoreAPI.APIReqResModels.User;
using BookstoreAPI.BusinessLogic.Interfaces;
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
        //admin
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userBL.GetAllUsersAsync();
            return users is not null ? StatusCode(StatusCodes.Status200OK, users) : StatusCode(StatusCodes.Status400BadRequest, "No users found");
        }
        
        [HttpGet(nameof(GetUserBooks))]
        //admin
        public async Task<ActionResult> GetUserBooks([FromQuery] string userId)
        {
            var books = await _userBL.GetUserBooksAsync(userId);
            return books is not null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest, "No books found");
        }

        // POST: UsersController/Create
        [HttpPost(nameof(Register))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([FromBody] UserRequestModel user)
        {
            var userToken = await _userBL.AddUserAsync(user);
            return userToken != String.Empty ? StatusCode(StatusCodes.Status200OK, userToken) : StatusCode(StatusCodes.Status400BadRequest, "Username not available");
        }

        // POST: UsersController/Edit/5
        [HttpPost(nameof(Login))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(int userId, string hashPassword)
        {
            return Ok();
        }

        [HttpPatch(nameof(Update))]
        //admin
        public async Task<ActionResult> Update(int userId, string userType)
        {
            return Ok();
        }

        [HttpPut(nameof(AddBookToUser))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBookToUser(string userId, string bookId)
        {
            var isSaved = await _userBL.AddBookToFavoriteAsync(userId, bookId);
            return StatusCode(StatusCodes.Status200OK, isSaved);
        }

        [HttpPut(nameof(RemoveBookFromUser))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveBookFromUser(string userId, string bookId)
        {
            var isRemoved = await _userBL.RemoveBookFromFavoriteAsync(userId, bookId);
            return StatusCode(StatusCodes.Status200OK, isRemoved);
        }
    }
}
