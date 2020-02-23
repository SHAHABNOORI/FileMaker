using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Employees;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Educations;
using FileMaker.Infrastructure.ViewModels.Employees;
using FileMaker.Infrastructure.ViewModels.Languages;
using FileMaker.Infrastructure.ViewModels.Origins;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Employees;

namespace FileMaker.Service.Implements.Modules.Employees
{
    public class EmployeeService : ApplicationService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// سرویس ثبت اطلاعات پرسنلی کارمند
        /// Employee Personal Info Create Service
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<Result> CreateEmployeePersonalInfoAsyn(CreateEmployeePersonalInfoCommand command)
        {
            try
            {
                var selectedOrigin = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(o => o.Id == command.OriginId);
                var selectedLanguage = await UnitOfWork.LanguagesRepository.FirstOrDefaultAsync(o => o.Id == command.LanguageId);
                var selectedEducation = await UnitOfWork.EducationRepository.FirstOrDefaultAsync(o => o.EducationId == command.EducationId);
                var selectedSkill = await UnitOfWork.SkillRepository.FirstOrDefaultAsync(o => o.SkillId == command.SkillId);
                var selectedDegree = await UnitOfWork.DegreeRepository.FirstOrDefaultAsync(o => o.DegreeId == command.DegreeId);

                var newEmployee = new Employee()
                {
                    Education = selectedEducation,
                    Name = command.Name,
                    Dob = command.Dob,
                    Gender = command.Gender,
                    Language = selectedLanguage,
                    NickName = command.NickName,
                    Title = command.Title,
                    Surname = command.Surname,
                    Status = command.Status,
                    SexualOrientation = command.SexualOrientation,
                    PassportNumber = command.PassportNumber,
                    Origin = selectedOrigin,
                    EmployeeDegrees = new List<EmployeeDegree>(),
                    EmployeeSkills = new List<EmployeeSkill>(),
                    PersonalNumber = command.PersonalNumber
                };

                EmployeeSkill employeeSkill = new EmployeeSkill { Skill = selectedSkill, Employee = newEmployee };
                newEmployee.EmployeeSkills.Add(employeeSkill);

                EmployeeDegree employeeDegree = new EmployeeDegree { Degree = selectedDegree, Employee = newEmployee };
                newEmployee.EmployeeDegrees.Add(employeeDegree);

                await UnitOfWork.EmployeeRepository.AddAsync(newEmployee);
                var result = await UnitOfWork.CompleteAsync();
                return result != 0 ? GenerateSuccessResult("ثبت", newEmployee.EmployeeNumber) :
                    GenerateFaidResult("ثبت");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<Result> GetEmployeePersonalInfoByEmployeeNumber(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> UpdateEmployeePersonalInfoAsyn(UpdateEmployeePersonalInfoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Result> GetEmployeeInfoByEmployeeNumber(int id)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(id);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            var viewModel = GenerateEmployeeInfoViewModel(selectedEmployee);

            return GenerateSuccessResult("دریافت", viewModel);
        }

        private EmployeeInfoViewModel GenerateEmployeeInfoViewModel(Employee selectedEmployee)
        {
            var viewModel = new EmployeeInfoViewModel()
            {
                Origin = new OriginViewModel()
                {
                    Id = selectedEmployee.Origin.Id,
                    OriginName = selectedEmployee.Origin.OriginName
                },
                Education = new EducationViewModel()
                {
                    EducationName = selectedEmployee.Education.EducationName,
                    Id = selectedEmployee.Education.EducationId
                },
                Name = selectedEmployee.Name,
                Dob = selectedEmployee.Dob,
                EmployeeNumber = selectedEmployee.EmployeeNumber,
                Gender = selectedEmployee.Gender,
                Language = new LanguageViewModel()
                {
                    Id = selectedEmployee.Language.Id,
                    LanguageName = selectedEmployee.Language.LanguageName
                },
                NickName = selectedEmployee.NickName,
                PassportNumber = selectedEmployee.PassportNumber,
                SexualOrientation = selectedEmployee.SexualOrientation,
                PersonalNumber = selectedEmployee.PersonalNumber,
                Surname = selectedEmployee.Surname,
                Status = selectedEmployee.Status,
                Title = selectedEmployee.Title
            };
            var degree = selectedEmployee.EmployeeDegrees.FirstOrDefault();
            if (degree != null)
            {
                viewModel.EmployeeDegree = new DegreeViewModel()
                {
                    DegreeName = degree.Degree.DegreeName,
                    Id = degree.Degree.DegreeId
                };
            }

            var skill = selectedEmployee.EmployeeSkills.FirstOrDefault();
            if (skill != null)
            {
                viewModel.EmployeeSkill = new SkillViewModel()
                {
                    SkillName = skill.Skill.SkillName,
                    Id = skill.Skill.SkillId
                };
            }
            return viewModel;
        }
    }
}