using System.Threading.Tasks;
using FileMaker.Commands.Modules.Employees;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Employees;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Employees
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeePersonalInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;

        public EmployeePersonalInfoController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeePersonalInfoCommand command)
        {
            var result = await _employeeService.CreateEmployeePersonalInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

    }
}