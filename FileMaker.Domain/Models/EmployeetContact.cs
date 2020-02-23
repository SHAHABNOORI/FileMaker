using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class EmployeetContact
    {
        public int EmployeeContactId { get; set; }
        
        public EmployeeContactType ContactType { get; set; }

        public string EmailAddress { get; set; }

        public string PostalCode { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public OkToContact OkToContact { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}