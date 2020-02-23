using System;
using System.Threading.Tasks;
using FileMaker.Dal.Repositories.Interfaces;

namespace FileMaker.Dal.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IClientRepository ClientRepository { get; }
        ILanguagesRepository LanguagesRepository { get; }
        IOriginsRepository OriginsRepository { get; }
        ISkillRepository SkillRepository { get; }
        IDegreeRepository DegreeRepository { get; }
        IEducationRepository EducationRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        #endregion

        void Update<TEntity>(TEntity entity);

        Task<int> CompleteAsync();

        int Complete();
    }
}