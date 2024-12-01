using MediatR;

namespace NTTData_Cafe.Features.Employees.Commands.DeleteEmployee
{
  public class DeleteEmployeeCommand : IRequest<bool>
  {
    public string EmployeeId { get; set; }
  }
}
