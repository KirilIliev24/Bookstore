using Bookstore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IBookServices
    {
        Task<List<Book>> GetBooks();
        Task<Book> AddBook(Book book);
        Task<Book> GetBookByID(string id);
    }
}
