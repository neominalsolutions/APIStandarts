using APIStandarts.Domain.Repositories;
using APIStandarts.Dtos;
using AutoMapper;
using MediatR;

namespace APIStandarts.Application.Features.Articles.WithComments
{
  public class GetArticleWithCommentHandler : IRequestHandler<ArticleWithCommentRequestDto, ArticleWithCommentsResponseDto>
  {
    private readonly IArticleRepository articleRepository;
    private readonly IMapper mapper;

    public GetArticleWithCommentHandler(IArticleRepository articleRepository, IMapper mapper)
    {
      this.articleRepository = articleRepository;
      this.mapper = mapper;
    }

    public async Task<ArticleWithCommentsResponseDto> Handle(ArticleWithCommentRequestDto request, CancellationToken cancellationToken)
    {
 
      var entity = await this.articleRepository.WithCommentsAsync(request.ArticleId);
      var response = this.mapper.Map<ArticleWithCommentsResponseDto>(entity);


      return await Task.FromResult(response);
    }
  }
}
