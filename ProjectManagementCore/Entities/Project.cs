﻿

using ProjectManagementDomain.Entities;

namespace ProjectManagementCore.Entities
{
    public class Project
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Domain { get; set; }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
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

        public Clients Clients { get; set; }
        public Teams Teams { get; set; }


    }

}
