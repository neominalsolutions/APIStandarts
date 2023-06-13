using Microsoft.EntityFrameworkCore;

namespace APIStandarts.Persistance.EF.Contexts
{
  public class ArticleDbContext: DbContext
  {

    public ArticleDbContext(DbContextOptions<ArticleDbContext> opt):base(opt)
    {

    }


  }
}
