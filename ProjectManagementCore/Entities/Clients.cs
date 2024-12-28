using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDomain.Entities
{
    public class Clients
    {
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
