using System.Threading.Tasks;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeInfoByEmployeeNumberAsync(int id);
    }
}