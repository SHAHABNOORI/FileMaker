using System.Threading.Tasks;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Languages;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Languages
{
    [ApiController]
    [Route("[controller]")]
    public class AllLanguagesController : ControllerBase
    {
        private readonly ILanguagesService _languagesService;

        public AllLanguagesController(ILanguagesService languagesService)
        {
            _languagesService = languagesService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _languagesService.GetAllLanguagesAsync();
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}