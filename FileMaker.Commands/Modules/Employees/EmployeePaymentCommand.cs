using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class EmployeePaymentCommand
    {
        public PaymentFrequency PaymentFrequency { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}