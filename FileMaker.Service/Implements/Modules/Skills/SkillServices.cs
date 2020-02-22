using System.Collections.Generic;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Skills;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Origins;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Skills;

namespace FileMaker.Service.Implements.Modules.Skills
{
    public class SkillServices : ApplicationService, ISkillServices
    {
        public SkillServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> GetAllSkillsAsync()
        {
            var result = await UnitOfWork.SkillRepository.GetAllAsync();
            var viewModels = new List<SkillViewModel>();
            foreach (var skill in result)
            {
                viewModels.Add(new SkillViewModel()
                {
                    Id = skill.SkillId,
                    SkillName = skill.SkillName
                });
            }
            return GenerateSuccessResult("دریافت", viewModels);
        }

        public async Task<Result> GetSkillByIdAsync(int id)
        {
            var result = await UnitOfWork.SkillRepository.FirstOrDefaultAsync(skill => skill.SkillId== id);
            return GenerateSuccessResult("دریافت", result);
        }

        public async Task<Result> CreateSkillAsync(CreateSkillCommand command)
        {
            var exist = UnitOfWork.OriginsRepository.Any(origin =>
                origin.OriginName == command.SkillName);
            if (exist) return GenerateBussimessFaidResult("عنوان انتخاب شده تکراری می باشد");

            await UnitOfWork.SkillRepository.AddAsync(new Skill()
            {
                SkillName = command.SkillName
            });

            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ثبت", null) :
                GenerateFaidResult("ثبت");
        }

        public async Task<Result> UpdateSkillAsync(UpdateSkillCommand command)
        {
            var exist = await UnitOfWork.SkillRepository.FirstOrDefaultAsync(
                skill => skill.SkillId == command.Id);
            if (exist == null) return GenerateBussimessFaidResult("درخواست مورد نظر یافت نشد");

            exist.SkillName = command.SkillName;
            UnitOfWork.Update(exist);
            var result = await UnitOfWork.CompleteAsync();
            return result != 0 ? GenerateSuccessResult("ویرایش", exist) :
                GenerateFaidResult("ویرایش");

        }
    }
}