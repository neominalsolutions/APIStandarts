using APIStandarts.Application.Features.Articles.Create;
using APIStandarts.Application.Features.Articles.Update;
using APIStandarts.Domain.Entities;
using APIStandarts.Domain.Repositories;
using APIStandarts.Dtos;
using APIStandarts.Infrastructure.Contracts;
using APIStandarts.Persistance.EF.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace APIStandarts.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticlesController : RequestBaseController
  {
    //private readonly ArticleCreateService ac;
    //private readonly ArticleUpdateService ap = new ArticleUpdateService();




    //public ArticlesController(ArticleCreateService ac, ArticleUpdateService ap, IMediator mediator)
    //{
    //  this.ac = ac;
    //  this.ap = ap;
    //  this.mediator = mediator;
    //}
    private readonly IArticleRepository articleRepository;
    private readonly IUnitOfWork<ArticleDbContext> unitOfWork;

    public ArticlesController(IMediator mediator, IArticleRepository articleRepository, IUnitOfWork<ArticleDbContext>  unitOfWork) :base(mediator)
    {
      this.articleRepository = articleRepository;
      this.unitOfWork = unitOfWork;
    }

    [HttpGet]

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<ArticleDto>), StatusCodes.Status200OK)]

    public IActionResult Get()
    {

      //var a = new Article(name:"A-1",authorId:"1");
      //a.Name = "sdsada";

      var model = new List<ArticleDto>
      {

        new ArticleDto
        {
          Id = Guid.NewGuid().ToString(),
          Name = "Test-1"
        },
        new ArticleDto
        {
           Id = Guid.NewGuid().ToString(),
          Name = "Test-2"
        }

      };

      return Ok(model);
    }

    // api/articles/1 // required
    // api/articles?id=1 // optional
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetById([FromRoute] string id)
    {

      var model = new ArticleDto
      {
        Id = id,
        Name = "Test-2"
      };

      return StatusCode(StatusCodes.Status200OK, model);
    }

    // [FromRoute] // GET
    // [FromBody]  // POST, PUT, PATCH, DELETE (Composite Key)
    // [FromHeader] // Client Accept-Language=tr-TR, client_id, client_secret, Authorization Bearer AccessToken
    // [FromQuery] // QueryString üzerinden istek yapma, ?filter=name='ali'&page=1&limit=10;
 
    // api/articles
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Validation Error.
    [ProducesResponseType(StatusCodes.Status403Forbidden)] // Permission takıldık
    [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Login Değil
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Not Found
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Exception
    // [Authorize(Roles = "Admin")] // 403
    // [Authorize] // 401
    public async Task<IActionResult> Create([FromBody] ArticleCreateDto articleCreateDto)
    {
      //this.ac.HandleAsync(articleCreateDto);

      // mediator send ile ilgili komutu çalıştırıyoruz.
     var entityId = await this.mediator.Send(articleCreateDto);

      
      return Created($"api/articles/{entityId}", entityId); // 201;
    }

    [HttpPost("withComments")] // attribute routing
    public async Task<IActionResult> CreatePostWithComments([FromBody] ArticleCreateDto articleCreateDto)
    {

      var article = new Article(name:articleCreateDto.Name, authorId:articleCreateDto.AuthorId);

      foreach (var item in articleCreateDto.Comments)
      {
        article.AddComment(item.Text, item.Description);
      }

      await this.articleRepository.AddAsync(article);
      await this.unitOfWork.SaveAsync();






      return Created($"api/articles/{Guid.NewGuid().ToString()}", articleCreateDto); // 201;
    }


    [HttpPost("addComments")] // attribute routing
    public async Task<IActionResult> AddComments([FromBody] AddCommentDto addCommentDto)
    {
      await this.mediator.Send(addCommentDto);

      return Created($"api/articles/{addCommentDto.ArticleId}/comments", addCommentDto); // 201;
    }


    [HttpGet("{id}/comments")]
    public async Task<IActionResult> GetArticleComments([FromRoute] string id)
    {
      return Ok();
    }


    // api/articles/1 {id:1,name:'makale2'}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]string id, [FromBody] ArticleUpdateDto articleUpdateDto)
    {



      if(id is null)
      {
        return NotFound();
      }

      articleUpdateDto.ArticleId = id;

      //this.ap.HandleAsync(articleUpdateDto);
      await this.mediator.Send(articleUpdateDto);

      // 204 yani apidan network üzerinden update işlemlerinde bir obje dönmek maliyetli olduğu için tercih edilmez.zaten client app son güncel update edilecek nesneye sahip.
      return NoContent();

    }

    // nested route yapısı
    // api/articles/1/comments/2
    [HttpPut("{articleid}/comments/{commentid}")]
    public IActionResult Update([FromRoute] string articleid, [FromRoute] string commentid, [FromBody] ArticleCommentUpdateDto articleUpdateDto)
    {
      
      // 204 yani apidan network üzerinden update işlemlerinde bir obje dönmek maliyetli olduğu için tercih edilmez.zaten client app son güncel update edilecek nesneye sahip.
      return NoContent();

    }

    [HttpDelete("{id}")]

    public IActionResult Delete([FromRoute] string id)
    {
      return NoContent();
    }


    [HttpDelete("{articleid}/comments/{commentid}")]
    public async Task<IActionResult> DeleteArticleComment([FromRoute] string articleid, string commentid)
    {
      var article = await articleRepository.WithCommentsAsync(articleid);
      article.DeleteComment(commentid);

      await articleRepository.UpdateAsync(article);
      await unitOfWork.SaveAsync();


      return NoContent();
    }

    // apiKey değerleri gibi
    // hassas verilerimi header üzerinden gönderelim

    [HttpGet("withApiKey")]
    public IActionResult GetArticles([FromHeader] string apiKey)
    {
      return Ok();
    }


    // filtereleme işlemleri sayfalama, sıralama gibi api endpointe attılan istekler opsiyone tanımlanmalıdır. Bu gibi durumlar için QueryString kullanmamız gerekir.

    [HttpGet("filters")]
    public IActionResult GetArticles(string? searchText, string orderBy, string orderColumn, int limit = 10, int page = 1)
    {
      return Ok();
    }


    [HttpGet("filters/v2")]
    public IActionResult GetArticles([FromQuery] FilterDto dto)
    {
      return Ok();
    }





  }
}
