using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeePaymentViewModel
    {
        public PaymentFrequency PaymentFrequency { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}