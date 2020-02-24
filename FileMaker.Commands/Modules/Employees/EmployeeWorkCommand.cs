using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class EmployeeWorkCommand
    {
        public JobTitle JobTitle { get; set; }

        public Department Department { get; set; }

        public string TimecardNo { get; set; }

        public Unit Unit { get; set; }

        public Shift Shift { get; set; }

        public Hour Hour { get; set; }
    }
}