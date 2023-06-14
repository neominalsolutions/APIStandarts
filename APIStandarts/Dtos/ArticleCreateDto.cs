using MediatR;

namespace APIStandarts.Dtos
{
  public  class ArticleCommentDto
  {
    public string Text { get; set; }
    public string Description { get; set; }

  }


  // IRequest interface Dtolar işaretleniyor.
  public class ArticleCreateDto:IRequest<string>
  {
    public string Name { get; set; }
    public string AuthorId { get; set; }
    public List<ArticleCommentDto> Comments { get; set; }

  }
}
