using System.Linq;
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
                .Include(employee => employee.Education)
                .Include(employee => employee.EmployeeDegrees).ThenInclude(x => x.Degree)
                .Include(employee => employee.EmployeeSkills).ThenInclude(x => x.Skill)
                .Include(employee => employee.Language)
                .Include(employee => employee.Origin)
                .FirstOrDefaultAsync(client => client.EmployeeNumber == id);
            return result;
        }
    }
}