

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectManagementDomain.Entities;
using ProjectManagementDomain.Enum;

namespace ProjectManagementCore.Entities
{
    public class Project
    {
        [BsonId] // Maps to MongoDB's _id field
        [BsonRepresentation(BsonType.ObjectId)] // Allows MongoDB to handle the ObjectId as a string
        public string Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public ProjectCategory Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? TentativeDate { get; set; }
        public int TeamId {  get; set; }
        public int ClientId { get; set; } 
        public bool IsActive { get; set; }
        public bool IsDeleted {  get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }

        public string? description { get; set; }
        [BsonIgnore]
        public Clients Clients { get; set; }
        [BsonIgnore]
        public Teams Teams { get; set; }


    }

}
