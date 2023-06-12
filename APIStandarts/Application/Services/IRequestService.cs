namespace APIStandarts.Application.Services
{
    public interface IRequestService<TRequestDto>
    {
    /// <summary>
    /// Request işleyip Response döndüren Method.
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
      Task HandleAsync(TRequestDto requestDto);
   
    }
}
