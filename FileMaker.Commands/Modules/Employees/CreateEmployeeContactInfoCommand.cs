using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class CreateEmployeeContactInfoCommand
    {
        public int EmployeeNumber { get; set; }

        public EmployeeContactInfoCommand EmployeeContactInfo { get; set; }

        public EmployeeAddressInfoCommand EmployeeAddressInfo { get; set; }

        public EmployeeEmergencyContactInfoCommand EmployeeEmergencyContactInfo { get; set; }
    }
}