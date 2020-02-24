using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class BankInfo
    {
        public int BankInfoId { get; set; }

        public SortCode SortCode { get; set; }

        public string AccountNo { get; set; }

        public AccountName AccountName { get; set; }

        public string Iban { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}