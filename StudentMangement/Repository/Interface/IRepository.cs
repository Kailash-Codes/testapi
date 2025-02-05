using System;
using System.Linq.Expressions;

namespace StudentMangement.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetConditionalAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task AddRange(List<TEntity> entity);
        void DeleteRange(List<TEntity> entity);
        Task DeleteAllAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> FirstOrDefault();

    }
}
