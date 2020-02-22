namespace FileMaker.Domain.Models
{
    public class EmployeeDegree
    {
        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }

        public int DegreeId { get; set; }

        public Degree Degree { get; set; }
    }
}