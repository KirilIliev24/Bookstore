using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static Bookstore.Core.Enums.Enums;

namespace Bookstore.Core.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string HashPassword { get; set; } = String.Empty;
        [JsonConverter(typeof(StringEnumConverter))]  // JSON.Net
        [BsonRepresentation(BsonType.String)]         // Mongo
        public UserRole Role { get; set; } = UserRole.Basic;
        public IEnumerable<Book> FavoriteBooks { get; set; } = new List<Book>();
    }
}
