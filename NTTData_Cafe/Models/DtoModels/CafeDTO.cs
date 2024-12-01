using System.ComponentModel.DataAnnotations;

namespace NTTData_Cafe.Models.DtoModels
{
  public class CafeDTO
  {
    public Guid CafeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public int NumberOfEmployees { get; set; }
    public string? Logo { get; set; }
  }
}
