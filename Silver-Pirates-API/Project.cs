using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silver_Pirates_API
{
    internal class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
