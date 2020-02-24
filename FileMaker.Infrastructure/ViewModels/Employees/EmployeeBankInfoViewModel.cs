using FileMaker.Infrastructure.Enums;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeeBankInfoViewModel
    {
        public SortCode SortCode { get; set; }

        public string BankName { get; set; }

        public string AccountNo { get; set; }

        public AccountName AccountName { get; set; }

        public string Iban { get; set; }
    }
}