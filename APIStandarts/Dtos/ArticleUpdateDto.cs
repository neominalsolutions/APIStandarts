using MediatR;

namespace APIStandarts.Dtos
{
  // update işlemlerinde id yazmayız id immutable olduğundan.
  // sadece mutable alanlar yazılmalıdır.
  // Update Delete işlemlerinde çalışırken IRequest olarak işaretliyoruz ki her hangi bir response döndürmeyeceğimiz anlamına geliyor.
  // Create,Get Response Döndürürüz.
  public class ArticleUpdateDto:IRequest
  {
    public string Name { get; set; }

  }


}
