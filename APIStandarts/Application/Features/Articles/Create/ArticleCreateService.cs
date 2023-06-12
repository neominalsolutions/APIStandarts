using APIStandarts.Application.Services;
using APIStandarts.Dtos;

namespace APIStandarts.Application.Features.Articles.Create
{
  public class ArticleCreateService : IRequestService<ArticleCreateDto>
  {
    public Task HandleAsync(ArticleCreateDto requestDto)
    {
      // veri tabanı vs işlemleri. Create ile ilgili işlemler.
      throw new NotImplementedException();
    }
  }
}
