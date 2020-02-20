using System.Threading.Tasks;
using FileMaker.Commands.Modules.Languages;
using FileMaker.Infrastructure;

namespace FileMaker.Service.Interfaces.Modules.Languages
{
    public interface ILanguagesService
    {
        Task<Result> GetAllLanguagesAsync();

        Task<Result> GetLanguageByIdAsync(int id);

        Task<Result> CreateLanguageAsyn(CreateLanguageCommand command);

        Task<Result> UpdateLanguageAsyn(UpdateLanguageCommand command);
    }
}