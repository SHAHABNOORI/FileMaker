using System.Collections.Generic;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Origins;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Origins;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Origins;

namespace FileMaker.Service.Implements.Modules.Origins
{
    public class OriginsService : ApplicationService, IOriginsService
    {
        public OriginsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> GetAllOriginsAsync()
        {
            var result = await UnitOfWork.OriginsRepository.GetAllAsync();
            var viewModels = new List<OriginViewModel>();
            foreach (var origin in result)
            {
                viewModels.Add(new OriginViewModel()
                {
                    Id = origin.Id,
                    OriginName= origin.OriginName
                });
            }
            return GenerateSuccessResult("دریافت", viewModels);
        }

        public async Task<Result> GetOriginByIdAsync(int id)
        {
            var result = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(origin => origin.Id == id);
            return GenerateSuccessResult("دریافت", result);
        }

        public async Task<Result> CreateOriginAsyn(CreateOriginCommand command)
        {
            var exist = UnitOfWork.OriginsRepository.Any(origin =>
                origin.OriginName == command.OriginName);
            if (exist) return GenerateBussimessFaidResult("عنوان انتخاب شده تکراری می باشد");

            await UnitOfWork.OriginsRepository.AddAsync(new Origin()
            {
                OriginName = command.OriginName
            });

            var result = await UnitOfWork.CompleteAsync();
            return result !=0 ? GenerateSuccessResult("ثبت", null) :
                GenerateFaidResult("ثبت");
        }

        public async Task<Result> UpdateOriginAsyn(UpdateOriginCommand command)
        {
            var exist = await UnitOfWork.OriginsRepository.FirstOrDefaultAsync(
                origin => origin.Id == command.Id);
            if (exist == null) return GenerateBussimessFaidResult("درخواست مورد نظر یافت نشد");

            exist.OriginName = command.OriginName;
            UnitOfWork.Update(exist);
            var result = await UnitOfWork.CompleteAsync();
            return result !=0 ? GenerateSuccessResult("ویرایش", exist) :
                GenerateFaidResult("ویرایش");

        }
    }
}