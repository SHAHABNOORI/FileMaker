using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class EmployeeEmergencyContact
    {
        public int EmployeeEmergenctContactId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public EmployeeRelation Relation { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}