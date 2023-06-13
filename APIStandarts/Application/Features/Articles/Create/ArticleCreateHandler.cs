using APIStandarts.Dtos;
using MediatR;

namespace APIStandarts.Application.Features.Articles.Create
{
  // servicler ise request handler olarak işaretlenir.
  public class ArticleCreateHandler : IRequestHandler<ArticleCreateDto, string>
  {
    public async Task<string> Handle(ArticleCreateDto request, CancellationToken cancellationToken)
    {
      return await Task.FromResult(Guid.NewGuid().ToString());
    }
  }
}
