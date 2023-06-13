using APIStandarts.Domain.Entities;
using APIStandarts.Infrastructure.Contracts;

namespace APIStandarts.Domain.Repositories
{
  public interface IArticleRepository:IRepository<Article>
  {
    IEnumerable<Article> WithComments();
   
  }
}
