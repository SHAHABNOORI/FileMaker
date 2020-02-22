using System.Threading.Tasks;
using FileMaker.Commands.Modules.Degrees;
using FileMaker.Commands.Modules.Languages;
using FileMaker.Commands.Modules.Origins;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Degrees;
using FileMaker.Service.Interfaces.Modules.Origins;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Origins
{
    [ApiController]
    [Route("[controller]")]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeServices _degreeServices;

        public DegreesController(IDegreeServices degreeServices)
        {
            _degreeServices = degreeServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDegreeCommand command)
        {
            var result = await _degreeServices.CreateDegreeAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateDegreeCommand command)
        {
            var result = await _degreeServices.UpdateDegreeAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}