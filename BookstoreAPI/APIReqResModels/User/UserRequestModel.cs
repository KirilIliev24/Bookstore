using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.APIReqResModels.User
{
    public class UserRequestModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashPassword { get; set; }
    }
}
