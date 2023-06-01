using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeebAPI
{
    public class Weeb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string weebName { get; set; }
        public string password { get; set;}
        public bool isAdmin { get; set; }
        public string profileImg { get; set; }
    }
}
