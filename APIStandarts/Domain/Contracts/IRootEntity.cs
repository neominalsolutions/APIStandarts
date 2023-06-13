namespace APIStandarts.Domain.Contracts
{
  public interface IRootEntity
  {
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    DateTime DeletedAt { get; set; }
    public bool IsDeleted { get; set; }

  }
}
