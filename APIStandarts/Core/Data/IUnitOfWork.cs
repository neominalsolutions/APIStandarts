using Microsoft.EntityFrameworkCore;

namespace APIStandarts.Core.Data
{
    public interface IUnitOfWork<TDbContext>
      where TDbContext : DbContext
    {
        Task SaveAsync(); // EF Auto Transaction Yöntemi
        Task CommitAsync(); // Manuel Transaction Yöntemi
    }
}
