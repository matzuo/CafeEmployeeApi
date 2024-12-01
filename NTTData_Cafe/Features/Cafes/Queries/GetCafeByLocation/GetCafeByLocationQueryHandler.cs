using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;
using NTTData_Cafe.Models.DtoModels;

namespace NTTData_Cafe.Features.Cafes.Queries.GetCafeByLocation
{
  public class GetCafeByLocationQueryHandler : IRequestHandler<GetCafeByLocationQuery, List<CafeDTO>>
  {
    private readonly NTTDataDbContext _context;

    public GetCafeByLocationQueryHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<List<CafeDTO>> Handle(GetCafeByLocationQuery request, CancellationToken cancellationToken)
    {
      var cafesQuery = _context.Cafes.AsQueryable();

      if (!String.IsNullOrEmpty(request.location))
      {
        cafesQuery = cafesQuery.Where(x => String.Equals(x.Location.ToLower(), request.location.ToLower()));
      }

      var cafes = await cafesQuery
        .GroupJoin( _context.Employees,
          cafe => cafe.CafeId,
          employee => employee.CafeId,
          (cafe, employees) => new CafeDTO
          {
            CafeId = cafe.CafeId,
            Description = cafe.Description,
            Name = cafe.Name,
            Location = cafe.Location,
            Logo = cafe.Logo,
            NumberOfEmployees = employees.Count()
          })
        .OrderByDescending(x => x.NumberOfEmployees)
        .ToListAsync();

      return cafes;
    }
  }
}
