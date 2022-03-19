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

        // POST: UsersController/Create
        [HttpPost(nameof(Register))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserRequestModel user)
        {
           
            var registerUser = await _userBL.AddUserAsync(user);
            return registerUser == true ? StatusCode(StatusCodes.Status200OK, registerUser) : StatusCode(StatusCodes.Status400BadRequest, "Username not available");

        }

        // POST: UsersController/Edit/5
        [HttpPost(nameof(Login))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(int id, IFormCollection collection)
        {
            return Ok();
        }

        [HttpPatch(nameof(Update))]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, IFormCollection collection)
        {
            return Ok();
        }

    }
}
