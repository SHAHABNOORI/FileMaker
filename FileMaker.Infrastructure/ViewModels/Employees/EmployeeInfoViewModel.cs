﻿using System;
using FileMaker.Infrastructure.Enums;
using FileMaker.Infrastructure.ViewModels.Educations;
using FileMaker.Infrastructure.ViewModels.Languages;
using FileMaker.Infrastructure.ViewModels.Origins;

namespace FileMaker.Infrastructure.ViewModels.Employees
{
    public class EmployeeInfoViewModel
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

        public  OriginViewModel Origin { get; set; }

        public  LanguageViewModel Language { get; set; }

        public  EducationViewModel Education { get; set; }

        public SkillViewModel EmployeeSkill { get; set; }

        public  DegreeViewModel EmployeeDegree { get; set; }
    }
}