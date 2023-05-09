using System.ComponentModel.DataAnnotations;

namespace Silver_Pirates_API
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<HourReport> Hours { get; set; }
    }
}
