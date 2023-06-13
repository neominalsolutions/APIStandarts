using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStandarts.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RequestBaseController : ControllerBase
  {
    protected readonly IMediator mediator;

    public RequestBaseController(IMediator mediator)
    {
      this.mediator = mediator;
    }



  }
}
