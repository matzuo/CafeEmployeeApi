using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;

namespace NTTData_Cafe.Features.Employees.Commands.DeleteEmployee
{
  public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
  {
    private readonly NTTDataDbContext _context;

    public DeleteEmployeeCommandHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
      var employee = await _context.Employees
          .FirstOrDefaultAsync(e => e.EmployeeID == request.EmployeeId, cancellationToken);

      if (employee == null)
      {
        return false;
      }

      _context.Employees.Remove(employee);

      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}
