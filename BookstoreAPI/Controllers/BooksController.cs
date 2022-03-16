using Bookstore.Core;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.RequestModels;
using BookstoreAPI.APIReqResModels.ResponceModels;
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
            try
            {
                var books = await _bookBL.GetBooks();
                return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An unexpected error occured {e.Message}");
            }
            
        }

        [HttpPost(nameof(AddBook))]
        public async Task<IActionResult> AddBook([FromBody] BookRequestModel book)
        {
            try
            {
                var responce = await _bookBL.AddBook(book);
                return Ok(responce);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet(nameof(GetBookById))]
        public async Task<IActionResult> GetBookById([FromQuery] string id)
        {
            try
            {
                var books = await _bookBL.GetBookByID(id);
                return books != null ? StatusCode(StatusCodes.Status200OK, books) : StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            
        }
    }
}