using System.ComponentModel.DataAnnotations;

namespace Silver_Pirates_API
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeProjectId { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
