using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDomain.Entities
{
    public class Teams
    {
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
