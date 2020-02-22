using System.Threading.Tasks;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Degrees;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Degrees
{
    [ApiController]
    [Route("[controller]")]
    public class AllDegreesController : ControllerBase
    {
        private readonly IDegreeServices _degreeServices;

        public AllDegreesController(IDegreeServices degreeServices)
        {
            _degreeServices = degreeServices;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _degreeServices.GetAllDegreesAsync();
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}