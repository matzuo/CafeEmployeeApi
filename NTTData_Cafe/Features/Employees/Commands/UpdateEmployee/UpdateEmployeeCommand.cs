using MediatR;

namespace NTTData_Cafe.Features.Employees.Commands.UpdateEmployee
{
  public class UpdateEmployeeCommand(string employeeID, string fullName, string email, string phoneNumber, string gender, DateTime startDate, Guid? cafeId) : IRequest<bool>
  {
    public string EmployeeID { get; } = employeeID;
    public string FullName { get; } = fullName;
    public string Email { get; } = email;
    public string PhoneNumber { get; } = phoneNumber;
    public string Gender { get; } = gender;
    public DateTime StartDate { get; } = startDate;
    public Guid? CafeId { get; } = cafeId;
  }
}
