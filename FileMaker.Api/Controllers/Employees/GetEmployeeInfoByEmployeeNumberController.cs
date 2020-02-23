using System.Threading.Tasks;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Employees;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Employees
{
    [ApiController]
    [Route("[controller]")]
    public class GetEmployeeInfoByEmployeeNumberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;

        public GetEmployeeInfoByEmployeeNumberController(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetEmployeeInfoByEmployeeNumber(id);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

    }
}