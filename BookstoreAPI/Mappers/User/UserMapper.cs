using AutoMapper;
using BookstoreAPI.APIReqResModels.User;

namespace BookstoreAPI.Mappers.User
{
    using Bookstore.Core.Models;
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //Source to Destination
            CreateMap<UserRequestModel, User>();
            CreateMap<User, UserResponceModel>();
        }
    }
}
