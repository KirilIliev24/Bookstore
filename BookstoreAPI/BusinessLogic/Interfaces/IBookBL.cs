using BookstoreAPI.APIReqResModels.Book;

namespace BookstoreAPI.BusinessLogic.Interfaces
{
    public interface IBookBL
    {
        Task<BookResponceModel> AddBook(BookRequestModel book);
        Task<List<BookResponceModel>> GetBooks();
        Task<BookResponceModel> GetBookByID(string id);
    }
}
