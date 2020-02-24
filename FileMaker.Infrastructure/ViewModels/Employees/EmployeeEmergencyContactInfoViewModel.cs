using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeeEmergencyContactInfoViewModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public EmployeeRelation Relation { get; set; }
    }
}