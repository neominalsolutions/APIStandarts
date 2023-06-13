using APIStandarts.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIStandarts.Infrastructure.Contracts
{
    // EF Multiple DbContext yapısını desteklediği için ve API uygulamaları daha sonradan Microservis uygulamalarına dönüşebileceği için Repositorylerde MultipleContext yapısına uygun yazarız
    public abstract class EFRepositoryBase<TDbContext, TRootEntity> : IRepository<TRootEntity>
      where TRootEntity : IRootEntity
      where TDbContext : DbContext
    {
        public virtual Task AddAsync(TRootEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TRootEntity> Find(string Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IQueryable<TRootEntity>> Query()
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(TRootEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TRootEntity>> Where(Expression<Func<TRootEntity, bool>> lamda)
        {
            throw new NotImplementedException();
        }
    }
}
