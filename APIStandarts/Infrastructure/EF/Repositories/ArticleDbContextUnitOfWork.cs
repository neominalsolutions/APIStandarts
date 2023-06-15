using APIStandarts.Core.Data;
using APIStandarts.Persistance.EF.Contexts;

namespace APIStandarts.Infrastructure.EF.Repositories
{
    public class ArticleDbContextUnitOfWork : IUnitOfWork<ArticleDbContext>
    {

        private ArticleDbContext dbContext;
        //private ArticleDbContext dbContext1;
        //ArticleDbContext dbContext1

        public ArticleDbContextUnitOfWork(ArticleDbContext dbContext)
        {
            this.dbContext = dbContext;
            //this.dbContext1 = dbContext1;
        }

        /// <summary>
        /// Manuel Transaction Yöntemi
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            //using (var tra1 = await dbContext1.Database.BeginTransactionAsync())
            //{
            using (var tra = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.SaveChangesAsync();
                    //await this.dbContext1.SaveChangesAsync();

                    await tra.CommitAsync();
                    //await tra1.CommitAsync();
                }
                catch (Exception)
                {
                    await tra.RollbackAsync();
                    //await tra1.RollbackAsync();
                }
            }
            //}
        }

        /// <summary>
        /// Auto Transaction Yöntemi
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync()
        {
            try
            {
                return dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

        }
    }
}
