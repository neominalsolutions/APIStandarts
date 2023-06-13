namespace APIStandarts.Domain.Entities
{
  public class Article // Root Entity
  {
    public string Id { get; init; } // Nesnenin sadece contructor üzerinden Id set edilecek
    public string Name { get; private set; } // required alanları private set tanımladık.
    public string? Description { get; set; }
    public string AuthorId { get; private set; }

    private List<Comment> _comments = new List<Comment>();
    public IReadOnlyCollection<Comment> Comments => _comments; // Commentlere direk dışarıdan müdahale edilmesin
    // Comment Child Entity.


    public Article(string name, string authorId)
    {
      Id = Guid.NewGuid().ToString();
      this.Name = name;
      this.AuthorId = authorId;

      //var a = new Article();
      //a.Name = "sadsda";
      //a.AddComment()
      //a.Comments.Add();
    }


    public void AddComment(string commentText, string userId)
    {
      var comment = new Comment(commentText, userId);
      _comments.Add(comment);

    }

    public void SetName(string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new Exception("Name alanı required bir alan");
      }

      Name = name.Trim();
    }

    public void SetComment(string description = "")
    {
      this.Description = description.Trim();
    }


 


  }
}
