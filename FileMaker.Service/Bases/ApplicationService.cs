using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Infrastructure;
using FileMaker.Infrastructure.Enums;

namespace FileMaker.Service.Bases
{
    public abstract class ApplicationService : IApplicationService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected ApplicationService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        protected Result GenerateSuccessResult(string message, object data)
        {
            return new Result()
            {
                Data = data,
                Type = ResultType.Success,
                Message = $"فرآیند {message} با موفقیت مواجه شد"
            };
        }

        protected Result GenerateFaidResult(string message)
        {
            return new Result()
            {
                Type = ResultType.Failed,
                Message = $"فرآیند {message} با  شکست مواجه شد"
            };
        }

        protected Result GenerateBussimessFaidResult(string message)
        {
            return new Result()
            {
                Type = ResultType.Failed,
                Message = message
            };
        }
    }
}