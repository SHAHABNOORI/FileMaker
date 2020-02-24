using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public PaymentFrequency PaymentFrequency { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }

    }
}