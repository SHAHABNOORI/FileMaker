using System.Threading.Tasks;
using FileMaker.Commands.Modules.Degrees;
using FileMaker.Infrastructure;

namespace FileMaker.Service.Interfaces.Modules.Degrees
{
    public interface IDegreeServices
    {
        Task<Result> GetAllDegreesAsync();

        Task<Result> GetDegreeByIdAsync(int id);

        Task<Result> CreateDegreeAsync(CreateDegreeCommand command);

        Task<Result> UpdateDegreeAsync(UpdateDegreeCommand command);
    }
}