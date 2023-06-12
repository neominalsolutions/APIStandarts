using APIStandarts.Application.Services;
using APIStandarts.Dtos;

namespace APIStandarts.Application.Features.Articles.Update
{
  public class ArticleUpdateService : IRequestService<ArticleUpdateDto>
  {
    public Task HandleAsync(ArticleUpdateDto requestDto)
    {
      throw new NotImplementedException();
    }
  }
}
