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

        public async Task<Result> UpdateEmployeePersonalInfoAsyn(UpdateEmployeePersonalInfoCommand command)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(command.EmployeeNumber);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");
            var selectedOrigin = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(o => o.Id == command.OriginId);
            var selectedLanguage = await UnitOfWork.LanguagesRepository.FirstOrDefaultAsync(o => o.Id == command.LanguageId);
            var selectedEducation = await UnitOfWork.EducationRepository.FirstOrDefaultAsync(o => o.EducationId == command.EducationId);
            var selectedSkill = await UnitOfWork.SkillRepository.FirstOrDefaultAsync(o => o.SkillId == command.SkillId);
            var selectedDegree = await UnitOfWork.DegreeRepository.FirstOrDefaultAsync(o => o.DegreeId == command.DegreeId);

            selectedEmployee.Education = selectedEducation;
            selectedEmployee.Name = command.Name;
            selectedEmployee.Dob = command.Dob;
            selectedEmployee.Gender = command.Gender;
            selectedEmployee.Language = selectedLanguage;
            selectedEmployee.NickName = command.NickName;
            selectedEmployee.Title = command.Title;
            selectedEmployee.Surname = command.Surname;
            selectedEmployee.Status = command.Status;
            selectedEmployee.SexualOrientation = command.SexualOrientation;
            selectedEmployee.PassportNumber = command.PassportNumber;
            selectedEmployee.Origin = selectedOrigin;
            selectedEmployee.PersonalNumber = command.PersonalNumber;
            selectedEmployee.EmployeeDegrees = new List<EmployeeDegree>();
            selectedEmployee.EmployeeSkills = new List<EmployeeSkill>();
            EmployeeSkill employeeSkill = new EmployeeSkill { Skill = selectedSkill, Employee = selectedEmployee };
            selectedEmployee.EmployeeSkills.Add(employeeSkill);

            EmployeeDegree employeeDegree = new EmployeeDegree { Degree = selectedDegree, Employee = selectedEmployee };
            selectedEmployee.EmployeeDegrees.Add(employeeDegree);

            UnitOfWork.Update(selectedEmployee);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }
        public async Task<Result> GetEmployeeInfoByEmployeeNumber(int id)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(id);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            var viewModel = GenerateEmployeeInfoViewModel(selectedEmployee);

            return GenerateSuccessResult("دریافت", viewModel);
        }

        public async Task<Result> CreateEmployeeContactInfoAsyn(CreateEmployeeContactInfoCommand command)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(command.EmployeeNumber);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            selectedEmployee.EmployeetContact = new EmployeetContact()
            {
                ContactType = command.EmployeeContactInfo.ContactType,
                EmailAddress = command.EmployeeContactInfo.EmailAddress,
                MobileNumber = command.EmployeeContactInfo.MobileNumber,
                OkToContact = command.EmployeeContactInfo.OkToContact,
                PostalCode = command.EmployeeContactInfo.PostalCode,
                PhoneNumber = command.EmployeeContactInfo.PhoneNumber
            };

            selectedEmployee.EmployeeAddress = new EmployeeAddress()
            {
                PostalCode = command.EmployeeAddressInfo.PostalCode,
                Address = command.EmployeeAddressInfo.Address,
                City = command.EmployeeAddressInfo.City,
                Email = command.EmployeeAddressInfo.Email,
                Town = command.EmployeeAddressInfo.Town
            };

            selectedEmployee.EmployeeEmergencyContact = new EmployeeEmergencyContact()
            {
                Name = command.EmployeeEmergencyContactInfo.Name,
                PhoneNumber = command.EmployeeEmergencyContactInfo.PhoneNumber,
                Relation = command.EmployeeEmergencyContactInfo.Relation
            };

            UnitOfWork.Update(selectedEmployee);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> UpdateEmployeeContactInfoAsyn(UpdateEmployeeContactInfoCommand command)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(command.EmployeeNumber);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            if (command.EmployeeContactInfo != null)
            {
                selectedEmployee.EmployeetContact.ContactType = command.EmployeeContactInfo.ContactType;
                selectedEmployee.EmployeetContact.EmailAddress = command.EmployeeContactInfo.EmailAddress;
                selectedEmployee.EmployeetContact.MobileNumber = command.EmployeeContactInfo.MobileNumber;
                selectedEmployee.EmployeetContact.OkToContact = command.EmployeeContactInfo.OkToContact;
                selectedEmployee.EmployeetContact.PostalCode = command.EmployeeContactInfo.PostalCode;
                selectedEmployee.EmployeetContact.PhoneNumber = command.EmployeeContactInfo.PhoneNumber;
            }

            if (command.EmployeeAddressInfo != null)
            {
                selectedEmployee.EmployeeAddress.PostalCode = command.EmployeeAddressInfo.PostalCode;
                selectedEmployee.EmployeeAddress.Address = command.EmployeeAddressInfo.Address;
                selectedEmployee.EmployeeAddress.City = command.EmployeeAddressInfo.City;
                selectedEmployee.EmployeeAddress.Email = command.EmployeeAddressInfo.Email;
                selectedEmployee.EmployeeAddress.Town = command.EmployeeAddressInfo.Town;
            }

            if (command.EmployeeEmergencyContactInfo != null)
            {
                selectedEmployee.EmployeeEmergencyContact.Name = command.EmployeeEmergencyContactInfo.Name;
                selectedEmployee.EmployeeEmergencyContact.PhoneNumber = command.EmployeeEmergencyContactInfo.PhoneNumber;
                selectedEmployee.EmployeeEmergencyContact.Relation = command.EmployeeEmergencyContactInfo.Relation;
;            }

            UnitOfWork.Update(selectedEmployee);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> CreateEmployeeRecruitmentInfoAsyn(CreateEmployeeRecruitmentInfoCommand command)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(command.EmployeeNumber);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            selectedEmployee.EmployeeRecruitment = new EmployeeRecruitment()
            {
                DateLeft = command.EmployeeRecruitment.DateLeft,
                DatePensionStarted = command.EmployeeRecruitment.DatePensionStarted,
                DateStarted = command.EmployeeRecruitment.DateStarted,
                InsuarenceNumber = command.EmployeeRecruitment.InsuarenceNumber,
                Reason = command.EmployeeRecruitment.Reason,
                Relationship = command.EmployeeRecruitment.Relationship,
                TypeOfEmployment = command.EmployeeRecruitment.TypeOfEmployment
            };

            selectedEmployee.Work = new Work()
            {
                Department = command.EmployeeWork.Department,
                Hour = command.EmployeeWork.Hour,
                JobTitle = command.EmployeeWork.JobTitle,
                Shift = command.EmployeeWork.Shift,
                TimecardNo = command.EmployeeWork.TimecardNo,
                Unit = command.EmployeeWork.Unit
            };

            selectedEmployee.BankInfo = new BankInfo()
            {
                AccountName = command.EmployeeBankInfo.AccountName,
                AccountNo = command.EmployeeBankInfo.AccountNo,
                Iban = command.EmployeeBankInfo.Iban,
                SortCode = command.EmployeeBankInfo.SortCode
            };

            selectedEmployee.Payment = new Payment()
            {
                PaymentFrequency = command.EmployeePayment.PaymentFrequency,
                PaymentMethod = command.EmployeePayment.PaymentMethod
            };

            UnitOfWork.Update(selectedEmployee);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
        }

        public async Task<Result> UpdateEmployeeRecruitmentInfoAsyn(UpdateEmployeeRecruitmentInfoCommand command)
        {
            var selectedEmployee = await UnitOfWork.EmployeeRepository.GetEmployeeInfoByEmployeeNumberAsync(command.EmployeeNumber);
            if (selectedEmployee == null)
                return GenerateFaidResult("کارمند مورد نظر یافت نشد");

            if (command.EmployeeRecruitment != null)
            {
                selectedEmployee.EmployeeRecruitment.DateLeft = command.EmployeeRecruitment.DateLeft;
                selectedEmployee.EmployeeRecruitment.DatePensionStarted = command.EmployeeRecruitment.DatePensionStarted;
                selectedEmployee.EmployeeRecruitment.DateStarted = command.EmployeeRecruitment.DateStarted;
                selectedEmployee.EmployeeRecruitment.InsuarenceNumber = command.EmployeeRecruitment.InsuarenceNumber;
                selectedEmployee.EmployeeRecruitment.Reason = command.EmployeeRecruitment.Reason;
                selectedEmployee.EmployeeRecruitment.Relationship = command.EmployeeRecruitment.Relationship;
                selectedEmployee.EmployeeRecruitment.TypeOfEmployment = command.EmployeeRecruitment.TypeOfEmployment;
            }

            if (command.EmployeeWork != null)
            {
                selectedEmployee.Work.Department = command.EmployeeWork.Department;
                selectedEmployee.Work.Hour = command.EmployeeWork.Hour;
                selectedEmployee.Work.JobTitle = command.EmployeeWork.JobTitle;
                selectedEmployee.Work.Shift = command.EmployeeWork.Shift;
                selectedEmployee.Work.TimecardNo = command.EmployeeWork.TimecardNo;
                selectedEmployee.Work.Unit = command.EmployeeWork.Unit;
            }

            if (command.EmployeeBankInfo != null)
            {
                selectedEmployee.BankInfo.AccountName = command.EmployeeBankInfo.AccountName;
                selectedEmployee.BankInfo.AccountNo = command.EmployeeBankInfo.AccountNo;
                selectedEmployee.BankInfo.Iban = command.EmployeeBankInfo.Iban;
                selectedEmployee.BankInfo.SortCode = command.EmployeeBankInfo.SortCode;
            }

            if (command.EmployeePayment != null)
            {
                selectedEmployee.Payment.PaymentFrequency = command.EmployeePayment.PaymentFrequency;
                selectedEmployee.Payment.PaymentMethod = command.EmployeePayment.PaymentMethod;
            }

            UnitOfWork.Update(selectedEmployee);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش ", null) :
                GenerateFaidResult("ویرایش ");
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