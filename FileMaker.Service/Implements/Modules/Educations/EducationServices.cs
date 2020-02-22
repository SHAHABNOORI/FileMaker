using System.Collections.Generic;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Educations;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Educations;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Educations;

namespace FileMaker.Service.Implements.Modules.Educations
{
    public class EducationServices : ApplicationService, IEducationServices
    {
        public EducationServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> GetAllEducationsAsync()
        {
            var result = await UnitOfWork.EducationRepository.GetAllAsync();
            var viewModels = new List<EducationViewModel>();
            foreach (var education in result)
            {
                viewModels.Add(new EducationViewModel()
                {
                    Id = education.EducationId,
                    EducationName = education.EducationName
                });
            }
            return GenerateSuccessResult("دریافت", viewModels);
        }

        public async Task<Result> GetEducationByIdAsync(int id)
        {
            var result = await UnitOfWork.EducationRepository.FirstOrDefaultAsync(education => education.EducationId == id);
            return GenerateSuccessResult("دریافت", result);
        }

        public async Task<Result> CreateEducationAsync(CreateEducationCommand command)
        {
            var exist = UnitOfWork.EducationRepository.Any(education =>
                education.EducationName == command.EducationName);
            if (exist) return GenerateBussimessFaidResult("عنوان انتخاب شده تکراری می باشد");

            await UnitOfWork.EducationRepository.AddAsync(new Education()
            {
                EducationName = command.EducationName
            });

            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ثبت", null) :
                GenerateFaidResult("ثبت");
        }


        public async Task<Result> UpdateEducationAsync(UpdateEducationCommand command)
        {
            var exist = await UnitOfWork.EducationRepository.FirstOrDefaultAsync(
                education => education.EducationId == command.Id);
            if (exist == null) return GenerateBussimessFaidResult("درخواست مورد نظر یافت نشد");

            exist.EducationName = command.EducationName;
            UnitOfWork.Update(exist);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش", exist) :
                GenerateFaidResult("ویرایش");

        }
    }
}