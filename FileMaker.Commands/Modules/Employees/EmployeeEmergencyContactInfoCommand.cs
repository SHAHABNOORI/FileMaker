using FileMaker.Domain.Models;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class EmployeeEmergencyContactInfoCommand
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public EmployeeRelation Relation { get; set; }
    }
}