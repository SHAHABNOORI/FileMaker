using System.Threading.Tasks;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Origins;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Origins
{
    [ApiController]
    [Route("[controller]")]
    public class AllOriginsController : ControllerBase
    {
        private readonly IOriginsService _originsService;

        public AllOriginsController(IOriginsService originsService)
        {
            _originsService = originsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _originsService.GetAllOriginsAsync();
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}