using MediatR;

namespace APIStandarts.Dtos
{
  // IRequest interface Dtolar işaretleniyor.
  public class ArticleCreateDto:IRequest<string>
  {
    public string Name { get; set; }
    public string AuthorId { get; set; }


  }
}
