namespace APIStandarts.Dtos
{
  // apidan entitylerin gerekli alanların export olması veya api gelen requestlerin dto import edilmesi ve validasyonların yapılması
  public class ArticleDto
  {
    public string Id { get; set; }
    public string Name { get; set; }

  }
}
