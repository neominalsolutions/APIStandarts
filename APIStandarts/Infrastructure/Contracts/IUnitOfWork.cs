using Microsoft.EntityFrameworkCore;

namespace APIStandarts.Infrastructure.Contracts
{
  public interface IUnitOfWork<TDbContext>
    where TDbContext:DbContext
  {
    Task SaveAsync(); // EF Auto Transaction Yöntemi
    Task CommitAsync(); // Manuel Transaction Yöntemi
  }
}
