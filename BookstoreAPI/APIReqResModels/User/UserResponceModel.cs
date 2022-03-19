
using static Bookstore.Core.Enums.Enums;


namespace BookstoreAPI.APIReqResModels.User
{
    using Bookstore.Core.Models;
    public class UserResponceModel
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Enum Role { get; set; }
        public IEnumerable<Book> FavoriteBooks { get; set; } = new List<Book>();
    }
}
