using AutoMapper;
using Bookstore.Core;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;
using BookstoreAPI.BusinessLogic.Interfaces;

namespace BookstoreAPI.BusinessLogic.Implementations
{
    public class BookBL : BaseBL<BookBL>, IBookBL
    {
        private readonly IBookServices _bookService;
        public BookBL(IBookServices bookServices, IMapper mapper) : base(mapper)
        {
            _bookService = bookServices;
        }
        public async Task<BookResponceModel> AddBook(BookRequestModel book)
        {
            //use mapper to change book request to book dbmodel
            var modelToSave = Mapper.Map<Book>(book);
            var dbbook = await _bookService.AddBook(modelToSave);

            //use mapper to conver bookdb model to responce model
            var returnModel = Mapper.Map<BookResponceModel>(dbbook);

            return returnModel;
        }

        public async Task<BookResponceModel> GetBookByID(string id)
        {
            var book = await _bookService.GetBookByID(id);
            var responce = Mapper.Map<BookResponceModel>(book);
            return responce;
        }

        public async Task<List<BookResponceModel>> GetBooks()
        {
            var dbbooks = await _bookService.GetBooks();
            if(dbbooks is not null)
            {
                return Mapper.Map<List<BookResponceModel>>(dbbooks);
            }
            return new List<BookResponceModel>();
            
        }
    }
}
