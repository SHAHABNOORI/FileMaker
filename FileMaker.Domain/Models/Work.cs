using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class Work
    {
        public int WorkId { get; set; }

        public JobTitle JobTitle { get; set; }

        public Department Department { get; set; }

        public string TimecardNo { get; set; }

        public Unit Unit { get; set; }

        public Shift Shift { get; set; }

        public Hour Hour { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}