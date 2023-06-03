using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthorsApi.Models
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public string Name { get; set; }
    }
}
