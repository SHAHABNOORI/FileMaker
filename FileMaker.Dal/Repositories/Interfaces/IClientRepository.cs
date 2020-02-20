using System.Threading.Tasks;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientBaseInfoByClientCode(int clientCode);
        Task<Client> GetClientInfoByClientCode(int clientCode);
    }
}