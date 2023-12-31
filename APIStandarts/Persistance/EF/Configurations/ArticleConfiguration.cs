﻿using APIStandarts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIStandarts.Persistance.EF.Configurations
{
  // FluentAPI
  // DataAnnotations [Required]
  public class ArticleConfiguration : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      //builder.ToTable("Makale");

      builder.HasIndex(x => x.Name).IsUnique(); // Unique indeks tanımı
      builder.Property(x => x.Name).HasMaxLength(50);
      builder.Property(x => x.Description).HasMaxLength(2000);
      //builder.Property(x => x.AuthorId).HasColumnName("YazarId");

      // EF Root Entity ve Child Entity arasında silme işlemlerinde FK alanları silinen kayot için NULL yapar. İlişkileri kopartır veriyi silmez. Eğer veriyi kalıcı olarak silmek istersek DeleteBehavior.Cascade yapmamız gerekir.
      builder.HasMany(x => x.Comments).WithOne().OnDelete(DeleteBehavior.Cascade);
     
      //builder.Property(x => x.Name).HasColumnName("Başlık");
      //builder.Property(x => x.Description).HasColumnName("Açıklama");

      

    }
  }
}
