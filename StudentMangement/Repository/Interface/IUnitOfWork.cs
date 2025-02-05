using Microsoft.EntityFrameworkCore.Storage;

namespace StudentMangement.Repository.Interface
{
    // IUnitOfWork.cs
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IDbContextTransaction BeginTransaction();
        Task<int> SaveChangesAsync();
    }

}