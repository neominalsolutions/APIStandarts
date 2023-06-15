using APIStandarts.Core.Data;
using APIStandarts.Domain.Entities;

namespace APIStandarts.Domain.Repositories
{
    public interface IArticleRepository:IRepository<Article>
  {
    Task<Article> WithCommentsAsync(string articleId);
   
  }
}
