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
    public class ClientBaseInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientServices _clientServices;

        public ClientBaseInfoController(IClientServices clientServices, IUnitOfWork unitOfWork)
        {
            _clientServices = clientServices;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientBaseInfoCommand command)
        {
            var result = await _clientServices.CreateClientBaseInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateClientBaseInfoCommand command)
        {
            var result = await _clientServices.UpdateClientBaseInfoAsyn(command);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }
    }
}