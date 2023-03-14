using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _03_WebApi_With_MongoDB.Models
{
    public class Candidate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Age { get; set; } = null!;
    }
}
