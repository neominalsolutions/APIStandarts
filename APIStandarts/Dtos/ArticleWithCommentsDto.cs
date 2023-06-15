using MediatR;
using System.Text.Json.Serialization;

namespace APIStandarts.Dtos
{
  public class CommentDto
  {
    [JsonPropertyName("commentText")]
    public string? Text { get; set; }

    [JsonPropertyName("commentBy")]
    public string? UserId { get; set; }
  }

  // QueryDto
  public class ArticleWithCommentsResponseDto
  {
    [JsonPropertyName("articleName")]
    public string? Name { get; set; }

    [JsonPropertyName("comments")]
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

  }

  public class ArticleWithCommentRequestDto:IRequest<ArticleWithCommentsResponseDto>
  {
    public string ArticleId { get; set; }

  }


 
}
