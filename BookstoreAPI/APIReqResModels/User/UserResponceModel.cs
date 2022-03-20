
using static Bookstore.Core.Enums.Enums;


namespace BookstoreAPI.APIReqResModels.User
{
    using Bookstore.Core.Models;
    public class UserResponceModel
    {
        public string? Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
