using APIStandarts.Domain.Entities;
using APIStandarts.Dtos;
using AutoMapper;

namespace APIStandarts.Application.Mappings.Articles
{
  public class ArticleMapping:Profile
  {
    public ArticleMapping()
    {

      CreateMap<Article, ArticleWithCommentsResponseDto>();
      CreateMap<Comment, CommentDto>();

    }
  }
}
