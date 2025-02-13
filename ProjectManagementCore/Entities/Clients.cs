using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectManagementDomain.Entities
{
    public class Clients
    {
        [BsonId] // Maps to MongoDB's _id field
        [BsonRepresentation(BsonType.ObjectId)] // Allows MongoDB to handle the ObjectId as a string
        public string Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime LastUpdatedOn { get; set; }
        //public string LastUpdatedBy { get; set; }
    }
}
