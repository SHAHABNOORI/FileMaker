using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeeContactInfoViewModel
    {
        public EmployeeContactType ContactType { get; set; }

        public string PostalCode { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public OkToContact OkToContact { get; set; }
    }
}