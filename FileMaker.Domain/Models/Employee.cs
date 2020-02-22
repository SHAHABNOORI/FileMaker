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

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        public virtual ICollection<EmployeeDegree> EmployeeDegrees { get; set; }
    }
}