using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace APIStandarts.Dtos
{
  public class FilterDto
  {

    public string? searchText { get; set; }

    public string? orderBy { get; set; }

    public string? thenBy { get; set; }

    public string? thenByColumn { get; set; }

    public string? orderColumn { get; set; }

    [DefaultValue(10)]
    public int limit { get; set; } = 10;


    [DefaultValue(1)]
    public int page { get; set; } = 1;

  }
}
