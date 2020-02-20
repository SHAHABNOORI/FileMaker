using System.Threading.Tasks;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure.Enums;
using FileMaker.Service.Interfaces.Modules.Clients;
using Microsoft.AspNetCore.Mvc;

namespace FileMaker.Api.Controllers.Clients
{
    [ApiController]
    [Route("[controller]")]
    public class GetClientBaseInfoByClientCodeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientServices _clientServices;

        public GetClientBaseInfoByClientCodeController(IClientServices clientServices, IUnitOfWork unitOfWork)
        {
            _clientServices = clientServices;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clientServices.GetClientBaseInfoByClientCode(id);
            return result.Type == ResultType.Success ? Ok(result.Data) : Problem(result.Message);
        }

    }
}