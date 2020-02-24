using FileMaker.Infrastructure.Enums;

namespace FileMaker.Commands.Modules.Employees
{
    public class EmployeeBankInfoCommand
    {
        public SortCode SortCode { get; set; }

        public string AccountNo { get; set; }

        public AccountName AccountName { get; set; }

        public string Iban { get; set; }
    }
}