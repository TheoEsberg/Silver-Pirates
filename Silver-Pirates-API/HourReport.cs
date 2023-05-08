using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silver_Pirates_API
{
    internal class HourReport
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime DateWorked { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
