using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("book")]
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string CoverArt { get; set; }

    }
}