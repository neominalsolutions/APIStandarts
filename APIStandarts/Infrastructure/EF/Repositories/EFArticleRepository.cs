using APIStandarts.Core.Data;
using APIStandarts.Domain.Entities;
using APIStandarts.Domain.Repositories;
using APIStandarts.Persistance.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace APIStandarts.Infrastructure.EF.Repositories
{
    public class EFArticleRepository: EFRepositoryBase<ArticleDbContext,Article>, IArticleRepository
  {
    public EFArticleRepository(ArticleDbContext context) : base(context)
    {
    }

    public override Task AddAsync(Article entity)
    {
      return base.AddAsync(entity);
    }

    public override Task UpdateAsync(Article entity)
    {
      return base.UpdateAsync(entity);
    }

    public async Task<Article> WithCommentsAsync(string articleId)
    {
      return await dbSet.Include(x => x.Comments).FirstAsync(x => x.Id == articleId);
    }
  }
}
