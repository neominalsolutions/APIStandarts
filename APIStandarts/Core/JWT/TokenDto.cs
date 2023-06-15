using System.Text.Json.Serialization;

namespace APIStandarts.Core.JWT
{
  public class TokenDto
  {
    public string AccessToken { get; set; }
    public string TokenType { get; set; }

  }
}
