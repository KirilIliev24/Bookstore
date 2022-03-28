using Bookstore.Core;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest, "Could not get books");
        }

        [HttpPost(nameof(AddBook))]
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> AddBook([FromBody] BookRequestModel book)
        {
            var responce = await _bookBL.AddBook(book);
            return responce != null ? StatusCode(StatusCodes.Status200OK, responce) : StatusCode(StatusCodes.Status400BadRequest, "Problems with adding book");
        }

        [HttpDelete(nameof(DeleteBookById))]
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> DeleteBookById([FromQuery] string bookId)
        {
            var isDeleted = await _bookBL.DeleteByIDAsync(bookId);
            return Ok(isDeleted);
        }

        [HttpPut(nameof(UpdateBookById))]
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> UpdateBookById([FromBody] BookRequestModel newModel, [FromRoute] string bookId)
        {
            var updatedBook = await _bookBL.UpdayteByIDAsync(newModel, bookId);
            return updatedBook is not null ? StatusCode(StatusCodes.Status200OK, updatedBook) : StatusCode(StatusCodes.Status400BadRequest, "Problems with updating the book");
        }

        [HttpGet(nameof(GetBookById))]
        public async Task<IActionResult> GetBookById([FromQuery] string id)
        {
            var books = await _bookBL.GetBookByID(id);
            return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest, "No books where found");
        }
    }
}