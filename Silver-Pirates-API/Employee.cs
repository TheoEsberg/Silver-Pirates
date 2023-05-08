using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silver_Pirates_API
{
    internal class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<HourReport> Hours { get; set; }

    }
}
