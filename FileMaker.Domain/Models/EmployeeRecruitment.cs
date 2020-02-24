using System;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class EmployeeRecruitment
    {
        public int EmployeeRecruitmentId { get; set; }

        public DateTime? DateStarted { get; set; }

        public DateTime? DateLeft { get; set; }

        public string Reason { get; set; }

        public DateTime? DatePensionStarted { get; set; }

        public string InsuarenceNumber { get; set; }

        public TypeOfEmployment TypeOfEmployment { get; set; }

        public EmployeeRecruitmentRelationShip Relationship { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}