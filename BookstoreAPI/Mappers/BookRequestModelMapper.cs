using AutoMapper;
using Bookstore.Core.Models;
using BookstoreAPI.APIReqResModels.RequestModels;

namespace BookstoreAPI.Mappers
{
    public class BookRequestModelMapper : Profile
    {
        public BookRequestModelMapper()
        {
            //Source to Destination
            CreateMap<BookRequestModel, Book>();
        }
    }
}
