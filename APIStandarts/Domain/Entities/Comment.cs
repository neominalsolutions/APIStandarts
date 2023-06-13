namespace APIStandarts.Domain.Entities
{
  public class Comment
  {
    public string Id { get; init; }

    public string Text { get; init; }

    public string UserId { get; init; }


    public DateTime CreatedAt { get; init; }

    //public string ArticleId { get; set; }

    //public Article Article { get; set; }




    // create new instance işlemleri için.
    public Comment(string text, string userId)
    {
      Id = Guid.NewGuid().ToString();
      this.UserId = userId;
      this.Text = text;
      CreatedAt = DateTime.Now;
    }

 



  }
}
