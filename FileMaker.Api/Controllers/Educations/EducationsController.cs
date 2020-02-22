using System.Threading.Tasks;
using FileMaker.Commands.Modules.Educations;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Educations;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Educations
{
    [ApiController]
    [Route("[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationServices _educationServices;

        public EducationsController(IEducationServices educationServices)
        {
            _educationServices = educationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEducationCommand command)
        {
            var result = await _educationServices.CreateEducationAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEducationCommand command)
        {
            var result = await _educationServices.UpdateEducationAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}