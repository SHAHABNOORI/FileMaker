using System;
using System.Collections.Generic;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Domain.Models
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string PersonalNumber { get; set; }

        public string Surname { get; set; }

        public DateTime? Dob { get; set; }

        public EmployeeStatus Status { get; set; }

       public string PassportNumber { get; set; }

        public Titles Title { get; set; }

        public Gender Gender { get; set; }

        public SexualOrientation SexualOrientation { get; set; }

        public virtual Origin Origin { get; set; }
        
        public virtual Language Language { get; set; }

        public virtual Education Education { get; set; }

        public virtual EmployeetContact EmployeetContact { get; set; }

        public virtual EmployeeAddress EmployeeAddress { get; set; }

        public virtual EmployeeRecruitment EmployeeRecruitment { get; set; }

        public virtual Work Work { get; set; }

        public virtual BankInfo BankInfo { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual EmployeeEmergencyContact EmployeeEmergencyContact { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        public virtual ICollection<EmployeeDegree> EmployeeDegrees { get; set; }
    }
}