using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileMaker.Dal.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Find Methods
        TEntity Get(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllAsNoTracking();

        Task<List<TEntity>> GetAllAsync();

        bool Any(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Add Methods

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        #endregion

        #region Remove

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion
    }
}