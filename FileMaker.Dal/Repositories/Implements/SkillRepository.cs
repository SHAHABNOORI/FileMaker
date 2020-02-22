using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Implements
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(FileMakerFinalContext context) : base(context)
        {
        }
    }
}