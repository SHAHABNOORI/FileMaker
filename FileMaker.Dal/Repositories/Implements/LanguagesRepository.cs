using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Domain.Contexts;
using FileMaker.Domain.Models;

namespace FileMaker.Dal.Repositories.Implements
{
    public class LanguagesRepository : Repository<Language>, ILanguagesRepository
    {
        public LanguagesRepository(FileMakerFinalContext context) : base(context)
        {
        }
    }
}