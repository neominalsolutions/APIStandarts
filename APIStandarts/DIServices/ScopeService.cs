namespace APIStandarts.DIServices
{
  public class ScopeService : IMSDI
  {
    public string Id { get; set; }

    public ScopeService()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
