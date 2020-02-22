using System.Threading.Tasks;
using FileMaker.Dal.Repositories.Implements;
using FileMaker.Dal.Repositories.Interfaces;
using FileMaker.Dal.UnitOfWork.Interfaces;
using FileMaker.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FileMaker.Dal.UnitOfWork.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FileMakerFinalContext _context;

        public UnitOfWork(FileMakerFinalContext context)
        {
            _context = context;
            EducationRepository = new EducationRepository(_context);
            LanguagesRepository = new LanguagesRepository(_context);
            ClientRepository = new ClientRepository(_context);
            OriginsRepository = new OriginsRepository(_context);
            SkillRepository = new SkillRepository(_context);
            DegreeRepository = new DegreeRepository(_context);
        }

        public IClientRepository ClientRepository { get; }
        public ILanguagesRepository LanguagesRepository { get; }
        public IOriginsRepository OriginsRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IDegreeRepository DegreeRepository { get; }
        public IEducationRepository EducationRepository { get; }

        public void Update<TEntity>(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}