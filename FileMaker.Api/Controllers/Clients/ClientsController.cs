//using System.Threading.Tasks;
//using FileMaker.Commands.Modules.Clients;
//using FileMaker.Commands.Modules.Languages;
//using FileMaker.Dal.UnitOfWork.Interfaces;
//using FileMaker.Service.Interfaces.Modules.Clients;
//using Microsoft.AspNetCore.Mvc;

//namespace FileMaker.Api.Controllers.Clients
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClientsController : OwnBaseController
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IClientServices _clientServices;

//        public ClientsController(IUnitOfWork unitOfWork,IClientServices clientServices)
//        {
//            _unitOfWork = unitOfWork;
//            _clientServices = clientServices;
//        }

//        //[HttpPost]
//        //public async Task<IActionResult> Post([FromBody] CreateClientBaseInfoCommand command)
//        //{
//        //    //var result = await _clientServices.cr(command);
//        //    //return GetResult(result);
//        //    return null;
//        //}

//    }
//}