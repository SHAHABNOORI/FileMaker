using System.Threading.Tasks;
using FileMaker.Commands.Modules.Skills;
using FileMaker.Infrastructure;

namespace FileMaker.Service.Interfaces.Modules.Skills
{
    public interface ISkillServices
    {
        Task<Result> GetAllSkillsAsync();

        Task<Result> GetSkillByIdAsync(int id);

        Task<Result> CreateSkillAsync(CreateSkillCommand command);

        Task<Result> UpdateSkillAsync(UpdateSkillCommand command);
    }
}