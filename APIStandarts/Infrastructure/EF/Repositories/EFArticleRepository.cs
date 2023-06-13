using APIStandarts.Domain.Entities;
using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.Contracts;
using APIStandarts.Persistance.EF.Contexts;

namespace APIStandarts.Infrastructure.EF.Repositories
{
  public class EFArticleRepository: EFRepositoryBase<ArticleDbContext,Article>, IArticleRepository
  {

    public override Task AddAsync(Article entity)
    {
      return base.AddAsync(entity);
    }

    public IEnumerable<Article> WithComments()
    {
      throw new NotImplementedException();
    }
  }
}
