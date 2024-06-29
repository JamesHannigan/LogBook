using LogBook.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LogBook.DataLayer.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
    {
        public ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> InsertAndCommit(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task InsertBatchAndCommit(List<TEntity> entities)
        {
            foreach(TEntity entity in entities)
            {
                await Insert(entity);
            }
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task<string> CommitChanges()
        {
            await _context.SaveChangesAsync();
            return string.Empty;
        }

        public virtual async Task<TEntity?> FindById(int id, bool forceRefresh = false)
        {
            var entity = await _context.Set<TEntity>().AsQueryable().SingleOrDefaultAsync(x => x.Id == id);

            if (forceRefresh && entity != null)
            {
                _context.Entry<TEntity>(entity).Reload();
            }

            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsQueryable().Where(t => t.Deleted == null).ToListAsync();
        }

        public async Task<List<TEntity>> GetMultipleByIds(List<int> ids)
        {
            return await _context.Set<TEntity>().AsQueryable().Where(t => t.Deleted == null && ids.Contains(t.Id)).ToListAsync(); 
        }

        public async Task SoftDeleteByIdAsync(int id)
        {
            TEntity? entity = await FindById(id);
            if(entity != null) SoftDelete(entity);
            await CommitChanges();
        }

        public void SoftDelete(TEntity entity)
        {
            entity.Deleted = DateTime.UtcNow;
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        public void DisposeTransaction()
        {
            _transaction.Dispose();
        }
    }
}
