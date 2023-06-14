using APIStandarts.Domain.Contracts;
using System.Linq.Expressions;

namespace APIStandarts.Infrastructure.Contracts
{
  public interface IRepository<TRootEntity> where TRootEntity:IRootEntity
  {
    // stateless
    Task AddAsync(TRootEntity entity);
    Task UpdateAsync(TRootEntity entity);
    Task DeleteAsync(string Id);

    // stateful

    Task<TRootEntity> Find(string Id);
    Task<IEnumerable<TRootEntity>> Where(Expression<Func<TRootEntity, bool>> lamda);

  IQueryable<TRootEntity> Query();


  }
}
