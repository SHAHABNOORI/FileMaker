using System.Collections.Generic;
using System.Threading.Tasks;
using FileMaker.Commands.Modules.Languages;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Models;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.ViewModels.Languages;
using FileMaker.Service.Bases;
using FileMaker.Service.Interfaces.Modules.Languages;

namespace FileMaker.Service.Implements.Modules.Languages
{
    public class LanguagesService : ApplicationService, ILanguagesService
    {

        public LanguagesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Result> GetAllLanguagesAsync()
        {
            var result = await UnitOfWork.LanguagesRepository.GetAllAsync();
            var viewModels = new List<LanguageViewModel>();
            foreach (var language in result)
            {
                viewModels.Add(new LanguageViewModel()
                {
                    Id = language.Id,
                    LanguageName = language.LanguageName
                });
            }
            return GenerateSuccessResult("دریافت", viewModels);
        }

        public async Task<Result> GetLanguageByIdAsync(int id)
        {
            var result = await UnitOfWork.LanguagesRepository.FirstOrDefaultAsync
                (language => language.Id == id);
            return GenerateSuccessResult("دریافت", result);
        }

        public async Task<Result> CreateLanguageAsyn(CreateLanguageCommand command)
        {
            var exist = UnitOfWork.LanguagesRepository.Any(language =>
                language.LanguageName == command.LanguageName);
            if (exist) return GenerateBussimessFaidResult("عنوان انتخاب شده تکراری می باشد");

            await UnitOfWork.LanguagesRepository.AddAsync(new Language()
            {
                LanguageName = command.LanguageName
            });

            var result = await UnitOfWork.CompleteAsync();
            return result == 1 ? GenerateSuccessResult("ثبت", null) :
                GenerateFaidResult("ثبت");
        }

        public async Task<Result> UpdateLanguageAsyn(UpdateLanguageCommand command)
        {
            var exist = await UnitOfWork.LanguagesRepository.FirstOrDefaultAsync(
                language => language.Id == command.Id);
            if (exist == null) return GenerateBussimessFaidResult("درخواست مورد نظر یافت نشد");

            exist.LanguageName = command.LanguageName;
            UnitOfWork.Update(exist);
            var result = await UnitOfWork.CompleteAsync();
            return result == 1 ? GenerateSuccessResult("ویرایش", exist) :
                GenerateFaidResult("ویرایش");
        }

    }
}