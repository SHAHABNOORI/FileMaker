using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class EmployeeAddressInfoCommand
    {
        public string Address { get; set; }

        public Town Town { get; set; }

        public City City { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }
    }
}