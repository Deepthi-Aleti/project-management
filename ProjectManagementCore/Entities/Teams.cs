
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagementDomain.Entities
{
    public class Teams
    {
        [BsonId] // Maps to MongoDB's _id field
        [BsonRepresentation(BsonType.ObjectId)] // Allows MongoDB to handle the ObjectId as a string
        public string Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public int Size { get; set; }
        public string Location { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
