using APIStandarts.Domain.Entities;
using APIStandarts.Dtos;
using APIStandarts.Persistance.EF.Contexts;
using MediatR;

namespace APIStandarts.Application.Features.Articles.Create
{
  // servicler ise request handler olarak işaretlenir.
  public class ArticleCreateHandler : IRequestHandler<ArticleCreateDto, string>
  {
    private readonly ArticleDbContext articleDb;

    public ArticleCreateHandler(ArticleDbContext articleDb)
    {
      this.articleDb = articleDb;
    }

    //[Exception]
    public async Task<string> Handle(ArticleCreateDto request, CancellationToken cancellationToken)
    {

      // 
      var entity = new Article(name: request.Name, authorId: request.AuthorId);

      try
      {
        await articleDb.Articles.AddAsync(entity);
        await articleDb.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw new Exception("Article db eklenirken bir hata meydana geldi"); // Status Code 500
      }


      return await Task.FromResult(entity.Id);
    }
  }
}
