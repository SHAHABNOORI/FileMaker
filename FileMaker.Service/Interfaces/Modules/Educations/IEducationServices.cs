using System.Threading.Tasks;
using FileMaker.Commands.Modules.Educations;
using FileMaker.Infrastructure;

namespace FileMaker.Service.Interfaces.Modules.Educations
{
    public interface IEducationServices
    {
        Task<Result> GetAllEducationsAsync();

        Task<Result> GetEducationByIdAsync(int id);

        Task<Result> CreateEducationAsync(CreateEducationCommand command);

        Task<Result> UpdateEducationAsync(UpdateEducationCommand command);
    }
}