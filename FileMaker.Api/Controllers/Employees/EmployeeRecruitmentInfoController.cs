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
    public class EmployeeRecruitmentInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;

        public EmployeeRecruitmentInfoController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRecruitmentInfoCommand command)
        {
            var result = await _employeeService.CreateEmployeeRecruitmentInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeRecruitmentInfoCommand command)
        {
            var result = await _employeeService.UpdateEmployeeRecruitmentInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}