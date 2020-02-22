using System.Threading.Tasks;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Skills;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Skills
{
    [ApiController]
    [Route("[controller]")]
    public class AllSkillsController : ControllerBase
    {
        private readonly ISkillServices _skillServices;

        public AllSkillsController(ISkillServices skillServices)
        {
            _skillServices = skillServices;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _skillServices.GetAllSkillsAsync();
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}