using System.Threading.Tasks;
using FileMaker.Commands.Modules.Clients;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Clients;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Clients
{
    [ApiController]
    [Route("[controller]")]
    public class ClientContactInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientServices _clientServices;

        public ClientContactInfoController(IClientServices clientServices, IUnitOfWork unitOfWork)
        {
            _clientServices = clientServices;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientContactInfoCommand command)
        {
            var result = await _clientServices.CreateClientContactInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

    }
}