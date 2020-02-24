using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class EmployeeAddress
    {
        public int EmployeeAddressId { get; set; }

        public string Address { get; set; }

        public Town Town { get; set; }

        public City City { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}