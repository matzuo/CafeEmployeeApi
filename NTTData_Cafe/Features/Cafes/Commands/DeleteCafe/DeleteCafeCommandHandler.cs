using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;

namespace NTTData_Cafe.Features.Cafes.Commands.DeleteCafe
{
  public class DeleteCafeCommandHandler : IRequestHandler<DeleteCafeCommand, bool>
  {
    private readonly NTTDataDbContext _context;

    public DeleteCafeCommandHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<bool> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
    {
      var cafe = await _context.Cafes
        .FirstOrDefaultAsync(e => e.CafeId == request.CafeId, cancellationToken);

      if (cafe == null)
      {
        return false;
      }

      var employees = await _context.Employees
                .Where(x => x.CafeId == request.CafeId)
                .ToListAsync(cancellationToken);

      if (employees.Any())
      {
        _context.Employees.RemoveRange(employees);
        await _context.SaveChangesAsync(cancellationToken);
      }

      _context.Cafes.Remove(cafe);

      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}
