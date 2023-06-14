using APIStandarts.Domain.Contracts;
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


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
      // Change Tracker ile Entity State değişimini izleyen bir sistem bu sistem ile nesne üzerinde stateleri takip edip ara operasyonları savechanges öncesi yapabiliriz.
      var entries = this.ChangeTracker.Entries().ToList();

      entries.ForEach(entry =>
      {

        if (entry.Entity is IRootEntity)
        {
          if (entry.State == EntityState.Added)
          {

            var entity = entry.Entity as RootEntity;
            entity.CreatedAt = DateTime.Now;

          }
          else if(entry.State == EntityState.Deleted)
          {
            var entity = entry.Entity as RootEntity;
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
          }
          else if(entry.State == EntityState.Modified)
          {
            var entity = entry.Entity as RootEntity;
            entity.UpdatedAt = DateTime.Now;
          }
        }
      });

      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    // Root Entity üzerindne Child Entityler erişim sağlayabiliyorsak bu durumda code defensing açısından Comments Dbset tanımlamamız doğru olmaz.

    //public DbSet<Comment> Comments { get; set; }


  }
}
