using MediatR;

namespace NTTData_Cafe.Features.Employees.Commands.CreateEmployee
{
  public class CreateEmployeeCommand(string fullName, string email, string phoneNumber, string gender, Guid? cafeId) : IRequest<string>
  {
    public string FullName { get; } = fullName;
    public string Email { get; } = email;
    public string PhoneNumber { get; } = phoneNumber;
    public string Gender { get; } = gender;
    public Guid? CafeId { get; } = cafeId;
  }
}
