using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.APIReqResModels.RequestModels
{
    public class BookRequestModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
    }
}
