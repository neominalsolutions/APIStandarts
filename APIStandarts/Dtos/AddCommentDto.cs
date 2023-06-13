using MediatR;

namespace APIStandarts.Dtos
{
  public class AddCommentDto:IRequest
  {
    public string ArticleId { get; set; }

    public string Text { get; set; }
    public string UserId { get; set; }

  }
}
