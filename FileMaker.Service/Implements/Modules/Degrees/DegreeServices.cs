using System.Collections.Generic;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Degrees;
using FileMaker.Commands.Modules.Skills;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Origins;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Degrees;
using FileMaker.Service.Interfaces.Modules.Skills;

namespace FileMaker.Service.Implements.Modules.Degrees
{
    public class DegreeServices : ApplicationService, IDegreeServices
    {
        public DegreeServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> GetAllDegreesAsync()
        {
            var result = await UnitOfWork.DegreeRepository.GetAllAsync();
            var viewModels = new List<DegreeViewModel>();
            foreach (var degree in result)
            {
                viewModels.Add(new DegreeViewModel()
                {
                    Id = degree.DegreeId,
                    DegreeName = degree.DegreeName
                });
            }
            return GenerateSuccessResult("دریافت", viewModels);
        }

        public async Task<Result> GetDegreeByIdAsync(int id)
        {
            var result = await UnitOfWork.DegreeRepository.FirstOrDefaultAsync(degree => degree.DegreeId == id);
            return GenerateSuccessResult("دریافت", result);
        }

        public async Task<Result> CreateDegreeAsync(CreateDegreeCommand command)
        {
            var exist = UnitOfWork.DegreeRepository.Any(degree =>
                degree.DegreeName == command.DegreeName);
            if (exist) return GenerateBussimessFaidResult("عنوان انتخاب شده تکراری می باشد");

            await UnitOfWork.DegreeRepository.AddAsync(new Degree()
            {
                DegreeName = command.DegreeName
            });

            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ثبت", null) :
                GenerateFaidResult("ثبت");
        }


        public async Task<Result> UpdateDegreeAsync(UpdateDegreeCommand command)
        {
            var exist = await UnitOfWork.DegreeRepository.FirstOrDefaultAsync(
                degree => degree.DegreeId == command.Id);
            if (exist == null) return GenerateBussimessFaidResult("درخواست مورد نظر یافت نشد");

            exist.DegreeName = command.DegreeName;
            UnitOfWork.Update(exist);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش", exist) :
                GenerateFaidResult("ویرایش");

        }
    }
}