using System.Threading.Tasks;
using FileMaker.Commands.Modules.Clients;
using FileMaker.Commands.Modules.Languages;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Languages;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Languages
{

    [ApiController]
    [Route("[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguagesService _languagesService;

        public LanguagesController(ILanguagesService languagesService)
        {
            _languagesService = languagesService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLanguageCommand command)
        {
            var result = await _languagesService.CreateLanguageAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLanguageCommand command)
        {
            var result = await _languagesService.UpdateLanguageAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}