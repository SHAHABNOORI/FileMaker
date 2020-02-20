using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Implements
{
    public class OriginsRepository : Repository<Origin>, IOriginsRepository
    {
        public OriginsRepository(FileMakerFinalContext context) : base(context)
        {
        }
    }
}