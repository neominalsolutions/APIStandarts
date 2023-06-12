namespace APIStandarts.DIServices
{
  public class TransientService: IMSDI
  {

    public string Id { get; set; }

    public TransientService()
    {
      Id = Guid.NewGuid().ToString();
    }

  }
}
