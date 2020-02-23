using System.Threading.Tasks;
using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FileMaker.Dal.Repositories.Implements
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(FileMakerFinalContext context) : base(context)
        {
        }

        public async Task<Employee> GetEmployeeInfoByEmployeeNumberAsync(int id)
        {
            var result = await Context.Employees
                .Include(client => client.Education)
                .Include(client => client.EmployeeDegrees)
                .Include(client => client.EmployeeSkills)
                .Include(client => client.Language)
                .Include(client => client.Origin)
                .FirstOrDefaultAsync(client => client.EmployeeNumber == id);
            return result;
        }
    }
}