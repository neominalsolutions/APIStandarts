using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIStandarts.Dtos
{
  // update işlemlerinde id yazmayız id immutable olduğundan.
  // sadece mutable alanlar yazılmalıdır.
  // Update Delete işlemlerinde çalışırken IRequest olarak işaretliyoruz ki her hangi bir response döndürmeyeceğimiz anlamına geliyor.
  // Create,Get Response Döndürürüz.
  public class ArticleUpdateDto:IRequest
  {
    [JsonPropertyName("articleName")]
    public string Name { get; set; }


    [JsonIgnore] // Swagger yansıtmak istemediğimiz prop için
    public string? ArticleId { get; set; }


   


  }


}
