using APIStandarts.Domain.Repositories;
using APIStandarts.Dtos;
using APIStandarts.Infrastructure.Contracts;
using APIStandarts.Persistance.EF.Contexts;
using MediatR;

namespace APIStandarts.Application.Features.Articles.Update
{
  public class ArticleUpdateHandler : IRequestHandler<ArticleUpdateDto>
  {
    private readonly IArticleRepository articleRepository;
    private readonly IUnitOfWork<ArticleDbContext> unitOfWork; 


    public ArticleUpdateHandler(IArticleRepository articleRepository, IUnitOfWork<ArticleDbContext> unitOfWork)
    {
      this.articleRepository = articleRepository;
      this.unitOfWork = unitOfWork;
    }

    public async Task Handle(ArticleUpdateDto request, CancellationToken cancellationToken)
    {
      var article =  await this.articleRepository.Find(request.ArticleId);

      article.SetName(request.Name);
      article.SetComment("Comment1");
      article.AddComment("Comment1", "1");
      article.AddComment("Comment2", "1");
      article.AddComment("Comment3", "1");

      await this.articleRepository.UpdateAsync(article); // state değişiminden sorumlu
      await this.unitOfWork.SaveAsync(); // save işleminden sorumlu, state değişikliğinin db yansımasından sorumlu.
      

      await Task.CompletedTask;
    }
  }
}
