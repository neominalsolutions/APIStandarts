using APIStandarts.Core.Domain;
using APIStandarts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIStandarts.Core.Data
{
    // EF Multiple DbContext yapısını desteklediği için ve API uygulamaları daha sonradan Microservis uygulamalarına dönüşebileceği için Repositorylerde MultipleContext yapısına uygun yazarız
    public abstract class EFRepositoryBase<TDbContext, TRootEntity> : IRepository<TRootEntity>
      where TRootEntity : RootEntity
      where TDbContext : DbContext
    {
        protected TDbContext dbContext; // db nesnesni
        protected DbSet<TRootEntity> dbSet; // tablonun kendisi

        public EFRepositoryBase(TDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TRootEntity>();
        }

        public virtual async Task AddAsync(TRootEntity entity)
        {
            await dbSet.AddAsync(entity); // Added State
        }

        public virtual Task DeleteAsync(string Id)
        {
            var entity = dbSet.Find(Id);
            if (entity is null)
            {
                throw new Exception("Entity bulunamadı");
            }

            dbSet.Remove(entity); // State Deleted oldu
            return Task.CompletedTask;

        }

        public virtual async Task<TRootEntity> Find(string Id)
        {

            return await dbSet.FindAsync(Id);

        }

        public virtual IQueryable<TRootEntity> Query()
        {
            return dbSet.AsNoTracking().AsQueryable(); // Sorgulama işlemleride kriter bazlı sorgulama için kullanılması gereken bir teknik. Performans takniği
        }

        public virtual Task UpdateAsync(TRootEntity entity)
        {
            dbSet.Update(entity); // Modified State 
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<TRootEntity>> Where(Expression<Func<TRootEntity, bool>> lamda)
        {
            // sorgularken sorgu performansını düşürmemk için.
            return await dbSet.AsNoTracking().Where(lamda).ToListAsync();
        }
    }
}
