using MediatR;
using NTTData_Cafe.Data;
using NTTData_Cafe.Helpers;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Features.Cafes.Commands.CreateCafe
{
  public class CreateCafeCommandHandler : IRequestHandler<CreateCafeCommand, Guid>
  {
    private readonly NTTDataDbContext _context;

    public CreateCafeCommandHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<Guid> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
    {

      var cafe = new Cafe
      {
        Description = request.Description,
        Location = request.Location,
        Logo = request.Logo,
        Name = request.Name
      };

      _context.Cafes.Add(cafe);

      await _context.SaveChangesAsync(cancellationToken);

      return cafe.CafeId;
    }
  }
}
