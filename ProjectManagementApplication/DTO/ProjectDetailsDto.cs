
using ProjectManagementDomain.Enum;

namespace ProjectManagementApplication.DTO
{
    public class ProjectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public ProjectCategory Category { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ReleaseDate { get; set; }

        public string? description { get; set; }

    }
}
