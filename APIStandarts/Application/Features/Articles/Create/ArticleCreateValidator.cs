using APIStandarts.Domain.Repositories;
using APIStandarts.Dtos;
using FluentValidation;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace APIStandarts.Application.Features.Articles.Create
{

  public class ArticleCreateValidator:AbstractValidator<ArticleCreateDto>
  {
    private readonly IArticleRepository articleRepository;

    public ArticleCreateValidator(IArticleRepository articleRepository)
    {
      this.articleRepository = articleRepository;

      RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("name alanı zorunludur");
      RuleFor(x => x.Name).Must(IsUnique).WithMessage("aynı makaleden mevcut");
      RuleFor(x => x.Comments).Must(CommentExists).WithMessage("En az 1 comment olmak zorundadır");
    }


    private bool CommentExists(List<ArticleCommentDto> articleCommentDtos)
    {
      if (articleCommentDtos.Count == 0)
        return false;

      return true;
    }
 

    private bool IsUnique(string name)
    {

      var entity = (this.articleRepository.Where(x => x.Name == name)).GetAwaiter().GetResult().FirstOrDefault();

      if(entity is not null)
        return false;

      return true; 

    }

  }
}
