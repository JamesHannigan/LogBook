using LogBook.Data.Models;

namespace LogBook.DataLayer.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<int> InsertAndCommit(TEntity entity);
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        void SoftDelete(TEntity entity);
        Task<string> CommitChanges();
        Task<TEntity?> FindById(int id, bool forceRefresh = false);
        Task<List<TEntity>> GetAll();
        Task InsertBatchAndCommit(List<TEntity> entities);
        Task SoftDeleteByIdAsync(int id);
        Task<List<TEntity>> GetMultipleByIds(List<int> ids);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }
}