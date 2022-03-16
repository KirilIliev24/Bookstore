namespace BookstoreAPI.APIReqResModels.ResponceModels
{
    public class BookResponceModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Category { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}
