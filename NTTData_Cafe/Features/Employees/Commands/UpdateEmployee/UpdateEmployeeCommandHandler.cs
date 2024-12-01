using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;

namespace NTTData_Cafe.Features.Employees.Commands.UpdateEmployee
{
  public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
  {
    private readonly NTTDataDbContext _context;

    public UpdateEmployeeCommandHandler(NTTDataDbContext context)
    {
      _context = context;
    }
    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
      var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeID == request.EmployeeID, cancellationToken);

      if (employee == null)
      {
        return false;
      }

      employee.FullName = request.FullName;
      employee.Email = request.Email;
      employee.PhoneNumber = request.PhoneNumber;
      employee.Gender = request.Gender;
      employee.CafeId = request.CafeId;

      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}
