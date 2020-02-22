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
    public class ClientPurchaceInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientServices _clientServices;

        public ClientPurchaceInfoController(IClientServices clientServices, IUnitOfWork unitOfWork)
        {
            _clientServices = clientServices;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientPurchaceInfoCommand command)
        {
            var result = await _clientServices.CreateClientPurchaceInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateClientPurchaceInfoCommand command)
        {
            var result = await _clientServices.UpdateClientPurchaceInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}