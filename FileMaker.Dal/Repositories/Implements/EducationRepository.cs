using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Implements
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        public EducationRepository(FileMakerFinalContext context) : base(context)
        {
        }
    }
}