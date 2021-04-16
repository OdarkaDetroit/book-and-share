using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models
{
    public class UsersBookshelf
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("users_bookshell")]

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }

        public string Location { get; set; }

    }
}