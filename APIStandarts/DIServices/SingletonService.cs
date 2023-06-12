namespace APIStandarts.DIServices
{
  public class SingletonService: IMSDI
  {
    public string Id { get; set; }

    public SingletonService()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
