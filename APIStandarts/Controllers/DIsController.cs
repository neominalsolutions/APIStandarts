using APIStandarts.DIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStandarts.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DIsController : ControllerBase
  {
    private TransientService t1;
    private TransientService t2;
    private ScopeService s1;
    private ScopeService s2;
    private SingletonService st1;
    private SingletonService st2;

    public DIsController(TransientService t1, TransientService t2, ScopeService s1, ScopeService s2, SingletonService st1, SingletonService st2)
    {
      this.t1 = t1;
      this.t2 = t2;
      this.s1 = s1;
      this.s2 = s2;
      this.st1 = st1;
      this.st2 = st2;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new
      {
        t1 = t1.Id,
        t2 = t2.Id,
        s1 = s1.Id,
        s2 = s2.Id,
        st1 = st1.Id,
        st2 = st2.Id
        
      });
    }
  }
}
