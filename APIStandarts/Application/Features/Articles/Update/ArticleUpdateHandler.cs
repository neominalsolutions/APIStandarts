using APIStandarts.Dtos;
using MediatR;

namespace APIStandarts.Application.Features.Articles.Update
{
  public class ArticleUpdateHandler : IRequestHandler<ArticleUpdateDto>
  {
    public async Task Handle(ArticleUpdateDto request, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
    }
  }
}
