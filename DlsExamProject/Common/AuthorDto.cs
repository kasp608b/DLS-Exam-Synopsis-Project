using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Common
{
    public class AuthorDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public string Name { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
