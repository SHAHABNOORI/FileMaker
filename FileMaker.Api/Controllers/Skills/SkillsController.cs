using System.Threading.Tasks;
using FileMaker.Commands.Modules.Skills;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Skills;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Skills
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillServices _skillServices;

        public SkillsController(ISkillServices skillServices)
        {
            _skillServices = skillServices;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            var result = await _skillServices.CreateSkillAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSkillCommand command)
        {
            var result = await _skillServices.UpdateSkillAsync(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}