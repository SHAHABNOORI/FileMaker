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
    public class EmployeeContactInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;

        public EmployeeContactInfoController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeContactInfoCommand command)
        {
            var result = await _employeeService.CreateEmployeeContactInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeContactInfoCommand command)
        {
            var result = await _employeeService.UpdateEmployeeContactInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}