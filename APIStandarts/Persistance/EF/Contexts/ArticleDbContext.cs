using APIStandarts.Domain.Entities;
using APIStandarts.Persistance.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace APIStandarts.Persistance.EF.Contexts
{
  public class ArticleDbContext: DbContext
  {

    public ArticleDbContext(DbContextOptions<ArticleDbContext> opt):base(opt)
    {

    }

    public DbSet<Article> Articles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Migration işlemlerinde buradaki kodlar uygulanıyor.
      modelBuilder.ApplyConfiguration(new ArticleConfiguration());

      base.OnModelCreating(modelBuilder);
    }

    // Root Entity üzerindne Child Entityler erişim sağlayabiliyorsak bu durumda code defensing açısından Comments Dbset tanımlamamız doğru olmaz.

    //public DbSet<Comment> Comments { get; set; }


  }
}
