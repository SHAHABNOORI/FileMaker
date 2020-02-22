using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Implements
{
    public class DegreeRepository : Repository<Degree>, IDegreeRepository
    {
        public DegreeRepository(FileMakerFinalContext context) : base(context)
        {
        }
    }
}