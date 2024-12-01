using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;

namespace NTTData_Cafe.Features.Cafes.Commands.UpdateCafe
{
  public class UpdateCafeCommandeHandler : IRequestHandler<UpdateCafeCommand, bool>
  {
    private readonly NTTDataDbContext _context;

    public UpdateCafeCommandeHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<bool> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
    {
      var cafe = await _context.Cafes
                .FirstOrDefaultAsync(e => e.CafeId == request.CafeId, cancellationToken);

      if (cafe == null)
      {
        return false;
      }

      cafe.Location = request.Location;
      cafe.Description = request.Description;
      cafe.Name = request.Name;
      cafe.Logo = request.Logo;

      await _context.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}
