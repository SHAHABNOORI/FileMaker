using System.Threading.Tasks;
using FileMaker.Commands.Modules.Clients;
using FileMaker.Infrastructure;
using FileMaker.Service.Bases;

namespace FileMaker.Service.Interfaces.Modules.Clients
{
    public interface IClientServices : IApplicationService
    {
        Task<Result> CreateClientBaseInfoAsyn(CreateClientBaseInfoCommand command);

        Task<Result> GetClientBaseInfoByClientCode(int id);

        Task<Result> UpdateClientBaseInfoAsyn(UpdateClientBaseInfoCommand command);

        Task<Result> CreateClientContactInfoAsyn(CreateClientContactInfoCommand command);

        Task<Result> GetClientInfoByClientCode(int id);

        Task<Result> CreateClientPurchaceInfoAsyn(CreateClientPurchaceInfoCommand command);

        Task<Result> UpdateClientPurchaceInfoAsyn(UpdateClientPurchaceInfoCommand command);
        
        Task<Result> UpdateClientContactInfoAsyn(UpdateClientContactInfoCommand command);
    }
}