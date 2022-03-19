using AutoMapper;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.Book;

namespace BookstoreAPI.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            //Source to Destination
            CreateMap<BookRequestModel, Book>();
            CreateMap<Book, BookResponceModel>();
        }
    }
}
