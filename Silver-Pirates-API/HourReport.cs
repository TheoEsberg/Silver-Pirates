using System.ComponentModel.DataAnnotations;

namespace Silver_Pirates_API
{
    public class HourReport
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime DateWorked { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}



