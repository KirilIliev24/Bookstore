using BookstoreAPI.APIReqResModels.Book;

namespace BookstoreAPI.BusinessLogic.Interfaces
{
    public interface IBookBL
    {
        Task<BookResponceModel> AddBook(BookRequestModel book);
        Task<List<BookResponceModel>> GetBooks();
        Task<BookResponceModel> GetBookByID(string id);
        Task<BookResponceModel> UpdayteByIDAsync(BookRequestModel newBook, string id);
        Task<bool> DeleteByIDAsync(string id);
    }
}
