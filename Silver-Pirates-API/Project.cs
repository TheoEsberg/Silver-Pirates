using System.ComponentModel.DataAnnotations;

namespace Silver_Pirates_API
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
