using System.Threading.Tasks;
using FileMaker.Commands.Modules.Origins;
using FileMaker.Infrastructure;
using FileMaker.Service.Bases;

namespace FileMaker.Service.Interfaces.Modules.Origins
{
    public interface IOriginsService : IApplicationService
    {
        Task<Result> GetAllOriginsAsync();

        Task<Result> GetOriginByIdAsync(int id);

        Task<Result> CreateOriginAsyn(CreateOriginCommand command);

        Task<Result> UpdateOriginAsyn(UpdateOriginCommand command);

    }
}