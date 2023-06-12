namespace APIStandarts.Dtos
{
  // update işlemlerinde id yazmayız id immutable olduğundan.
  // sadece mutable alanlar yazılmalıdır.
  public class ArticleUpdateDto
  {
    public string Name { get; set; }

  }
}
