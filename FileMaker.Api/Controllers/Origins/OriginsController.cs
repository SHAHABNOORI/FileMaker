using System.Threading.Tasks;
using FileMaker.Commands.Modules.Languages;
using FileMaker.Commands.Modules.Origins;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Origins;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Origins
{
    [ApiController]
    [Route("[controller]")]
    public class OriginsController : ControllerBase
    {
        private readonly IOriginsService _originsService;

        public OriginsController(IOriginsService originsService)
        {
            _originsService = originsService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOriginCommand command)
        {
            var result = await _originsService.CreateOriginAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOriginCommand command)
        {
            var result = await _originsService.UpdateOriginAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}