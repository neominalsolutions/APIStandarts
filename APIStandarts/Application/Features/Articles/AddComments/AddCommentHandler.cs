using APIStandarts.Dtos;
using APIStandarts.Persistance.EF.Contexts;
using MediatR;

namespace APIStandarts.Application.Features.Articles.AddComments
{
  public class AddCommentHandler : IRequestHandler<AddCommentDto>
  {
    private readonly ArticleDbContext db;


    public AddCommentHandler(ArticleDbContext db)
    {
      this.db = db;
    }
    public async Task Handle(AddCommentDto request, CancellationToken cancellationToken)
    {

      var article = db.Articles.Find(request.ArticleId);

      if(article == null)
      {
        throw new Exception("Makale bulunamadı");
      }

      try
      {
        article.AddComment(commentText: request.Text, userId: request.UserId);
        await db.SaveChangesAsync();
      }
      catch (Exception)
      {

        throw new Exception("Yorum eklenirken hata oluştu");
      }

   
    }
  }
}
