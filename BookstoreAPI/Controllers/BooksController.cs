using Bookstore.Core;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookBL _bookBL;
        public BooksController(IBookBL bookBL)
        {
            _bookBL = bookBL;
        }

        [HttpGet(nameof(GetBooks))]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookBL.GetBooks();
            return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPost(nameof(AddBook))]
        public async Task<IActionResult> AddBook([FromBody] BookRequestModel book)
        {
            var responce = await _bookBL.AddBook(book);
            return responce != null ? StatusCode(StatusCodes.Status200OK, responce) : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet(nameof(GetBookById))]
        public async Task<IActionResult> GetBookById([FromQuery] string id)
        {
            var books = await _bookBL.GetBookByID(id);
            return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}