namespace FileMaker.Commands.Modules.Employees
{
    public class CreateEmployeeRecruitmentInfoCommand
    {
        public int EmployeeNumber { get; set; }

        public EmployeeRecruitmentCommand EmployeeRecruitment { get; set; }

        public EmployeeWorkCommand EmployeeWork { get; set; }

        public EmployeeBankInfoCommand EmployeeBankInfo { get; set; }

        public EmployeePaymentCommand EmployeePayment { get; set; }
    }
}