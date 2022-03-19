using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.APIReqResModels.User
{
    public class UserRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashPassword { get; set; }
    }
}
