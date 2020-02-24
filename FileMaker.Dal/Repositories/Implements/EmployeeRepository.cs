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
                .Include(employee => employee.BankInfo)
                .Include(employee => employee.EmployeeAddress)
                .Include(employee => employee.EmployeeEmergencyContact)
                .Include(employee => employee.EmployeeRecruitment)
                .Include(employee => employee.EmployeetContact)
                .Include(employee => employee.Work)
                .Include(employee => employee.Payment)
                .FirstOrDefaultAsync(client => client.EmployeeNumber == id);
            return result;
        }
    }
}