using FileMaker.Infrastructure;
using FileMaker.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api
{
    public class OwnBaseController : ControllerBase
    {
        public IActionResult GetResult(Result result)
        {
            return result.Type == ResultType.Success ? (IActionResult)Ok(result.Data) : Problem(result.Message);
        }
    }
}