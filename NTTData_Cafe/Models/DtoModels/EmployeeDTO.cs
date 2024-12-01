using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Models.DtoModels
{
  public class EmployeeDTO
  {
    public string EmployeeID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfDaysWorked { get; set; }
    public string CafeName { get; set; }
    public Guid? CafeId { get; set; }
  }
}
