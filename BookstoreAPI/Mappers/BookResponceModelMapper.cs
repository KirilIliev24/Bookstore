using AutoMapper;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.ResponceModels;

namespace BookstoreAPI.Mappers
{
    public class BookResponceModelMapper : Profile
    {
        public BookResponceModelMapper()
        {
            CreateMap<Book, BookResponceModel>();
        }
    }
}
