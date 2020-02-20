using System.Threading.Tasks;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Clients;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Clients
{
    [ApiController]
    [Route("[controller]")]
    public class GetClientInfoByClientCodeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientServices _clientServices;

        public GetClientInfoByClientCodeController(IClientServices clientServices, IUnitOfWork unitOfWork)
        {
            _clientServices = clientServices;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clientServices.GetClientInfoByClientCode(id);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

    }
}