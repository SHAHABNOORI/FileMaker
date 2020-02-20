using System.Threading.Tasks;
using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FileMaker.Dal.Repositories.Implements
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(FileMakerFinalContext context) : base(context)
        {
        }

        public async Task<Client> GetClientBaseInfoByClientCode(int clientCode)
        {
            var result = await Context.Clients
                .Include(client => client.Language)
                .Include(client => client.Origin)
                .FirstOrDefaultAsync(client => client.ClientCode == clientCode);
            return result;
        }

        public async Task<Client> GetClientInfoByClientCode(int clientCode)
        {
            var result = await Context.Clients
                .Include(client => client.Language)
                .Include(client => client.Origin)
                .Include(client => client.ClientAddress)
                .Include(client => client.ClientDeliveryAddress)
                .Include(client => client.ClientContact)
                .FirstOrDefaultAsync(client => client.ClientCode == clientCode);
            return result;
        }
    }
}