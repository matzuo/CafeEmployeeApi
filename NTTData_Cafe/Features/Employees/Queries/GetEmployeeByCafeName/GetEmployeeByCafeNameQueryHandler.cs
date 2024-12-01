using MediatR;
using Microsoft.EntityFrameworkCore;
using NTTData_Cafe.Data;
using NTTData_Cafe.Helpers;
using NTTData_Cafe.Models.DtoModels;

namespace NTTData_Cafe.Features.Employees.Queries.GetEmployeeByCafeName
{
  public class GetEmployeeByCafeNameQueryHandler : IRequestHandler<GetEmployeeByCafeNameQuery, List<EmployeeDTO>>
  {
    private readonly NTTDataDbContext _context;

    public GetEmployeeByCafeNameQueryHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<List<EmployeeDTO>> Handle(GetEmployeeByCafeNameQuery request, CancellationToken cancellationToken)
    {
      var employeesQuery = _context.Employees.AsQueryable();

      if (!String.IsNullOrEmpty(request.cafeName))
      {
        employeesQuery = employeesQuery.Where(x => String.Equals(x.Cafe.Name.ToLower(), request.cafeName.ToLower()));
      }

      var employees = await employeesQuery
        .Select(x => new EmployeeDTO { 
          EmployeeID = x.EmployeeID,
          Email = x.Email,
          FullName = x.FullName,
          PhoneNumber = x.PhoneNumber,
          StartDate = x.StartDate,
          NumberOfDaysWorked = x.StartDate.CalculateDaysWorked(),
          CafeName = x.Cafe.Name,
          CafeId = x.CafeId,
          Gender = x.Gender
        })
        .ToListAsync();

      return employees.OrderByDescending(x => x.NumberOfDaysWorked).ToList();
    }
  }
}
