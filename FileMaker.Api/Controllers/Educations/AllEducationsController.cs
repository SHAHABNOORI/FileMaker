using System.Threading.Tasks;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Educations;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Educations
{
    [ApiController]
    [Route("[controller]")]
    public class AllEducationsController : ControllerBase
    {
        private readonly IEducationServices _educationServices;

        public AllEducationsController(IEducationServices educationServices)
        {
            _educationServices = educationServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _educationServices.GetAllEducationsAsync();
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}