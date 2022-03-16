using Bookstore.Core;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookService;
        public BooksController(IBookServices bookServices)
        {
            _bookService = bookServices;
        }

        [HttpGet(nameof(GetBooks))]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpPost(nameof(AddBook))]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return Ok(book);
            }
            catch (Exception e)
            {
                throw;
            }
            
            
        }
    }
}